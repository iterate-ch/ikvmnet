﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

namespace IKVM.JTReg.TestAdapter
{

    [DefaultExecutorUri("executor://ikvmjtregtestadapter/v1")]
    [FileExtension(".dll")]
    [FileExtension(".exe")]
    public class IkvmJTRegTestDiscoverer : IkvmJTRegTestAdapter, ITestDiscoverer
    {


        /// <summary>
        /// Discovers the available OpenJDK tests.
        /// </summary>
        /// <param name="sources"></param>
        /// <param name="discoveryContext"></param>
        /// <param name="logger"></param>
        /// <param name="discoverySink"></param>
        public void DiscoverTests(IEnumerable<string> sources, IDiscoveryContext discoveryContext, IMessageLogger logger, ITestCaseDiscoverySink discoverySink)
        {
            if (sources is null)
                throw new ArgumentNullException(nameof(sources));
            if (discoveryContext is null)
                throw new ArgumentNullException(nameof(discoveryContext));
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));
            if (discoverySink is null)
                throw new ArgumentNullException(nameof(discoverySink));

            try
            {
                foreach (var source in sources)
                    DiscoverTests(source, discoveryContext, logger, discoverySink);
            }
            catch (Exception e)
            {
                logger.SendMessage(TestMessageLevel.Error, "JTReg: " + $"An exception occurred discovering tests.\n\n{e.Message}\n{e.StackTrace}");
            }
        }

        /// <summary>
        /// Discovers the available tests.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="discoveryContext"></param>
        /// <param name="logger"></param>
        /// <param name="discoverySink"></param>
        internal void DiscoverTests(string source, IDiscoveryContext discoveryContext, IMessageLogger logger, ITestCaseDiscoverySink discoverySink)
        {
            if (string.IsNullOrEmpty(source))
                throw new ArgumentException($"'{nameof(source)}' cannot be null or empty.", nameof(source));
            if (discoveryContext is null)
                throw new ArgumentNullException(nameof(discoveryContext));
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));
            if (discoverySink is null)
                throw new ArgumentNullException(nameof(discoverySink));

            try
            {
                // normalize source path
                source = Path.GetFullPath(source);
                logger.SendMessage(TestMessageLevel.Informational, "JTReg: " + $"Scanning for test roots for '{source}'.");

                // discover all root test directories
                var testDirs = new java.util.ArrayList();
                foreach (var rootFile in Directory.GetFiles(Path.GetDirectoryName(source), TEST_ROOT_FILE_NAME, SearchOption.AllDirectories))
                {
                    logger.SendMessage(TestMessageLevel.Informational, "JTReg: " + $"Found test root file: {rootFile}");
                    testDirs.add(new java.io.File(Path.GetDirectoryName(rootFile)));
                }

                // output path for jtreg state
                var id = GetSourceHash(source);
                var baseDir = Path.Combine(Path.GetTempPath(), BASEDIR_PREFIX + id);

                // attempt to create a temporary directory as scratch space for this test
                logger.SendMessage(TestMessageLevel.Informational, "JTReg: " + $"Using run directory: {baseDir}");
                Directory.CreateDirectory(baseDir);

                using var output = new java.io.PrintWriter(Path.Combine(baseDir, DEFAULT_OUT_FILE_NAME));
                using var errors = new StreamWriter(File.OpenWrite(Path.Combine(baseDir, DEFAULT_LOG_FILE_NAME)));

                // initialize the test manager with the discovered roots
                var testManager = CreateTestManager(logger, baseDir, output, errors);
                testManager.addTestFiles(testDirs, false);

                // track metrics related to tests
                int testCount = 0;
                var testWatch = new Stopwatch();
                testWatch.Start();

                // for each suite, get the results and transform a test case
                foreach (dynamic testSuite in Util.GetTestSuites(source, testManager))
                {
                    logger.SendMessage(TestMessageLevel.Informational, "JTReg: " + $"Discovered test suite: {testSuite.getName()}");

                    foreach (var testResult in GetTestResults(source, testSuite, CreateParameters(source, baseDir, testManager, testSuite, null)))
                    {
                        var testCase = (TestCase)Util.ToTestCase(source, testSuite, testResult, testCount++ % PARTITION_COUNT);
                        logger.SendMessage(TestMessageLevel.Informational, "JTReg: " + $"Discovered test: {testCase.FullyQualifiedName}");
                        discoverySink.SendTestCase(testCase);
                    }
                }

                testWatch.Stop();
                logger.SendMessage(TestMessageLevel.Informational, "JTReg: " + $"Discovered {testCount} tests for '{source}' in {testWatch.Elapsed.TotalSeconds} seconds.");
            }
            catch (Exception e)
            {
                logger.SendMessage(TestMessageLevel.Error, "JTReg: " + $"An exception occurred discovering tests for '{source}'.\n\n{e.Message}\n{e.StackTrace}");
            }
        }


    }

}