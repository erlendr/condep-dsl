﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConDep.Dsl.Config;
using ConDep.Dsl.Remote;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using NUnit.Framework;

namespace ConDep.Dsl.Tests
{
    [TestFixture]
    public class HarvesterTests
    {
        private UnitTestLogger CreateMemoryLogger()
        {
            var memAppender = new MemoryAppender { Name = "MemoryAppender" };
            memAppender.ActivateOptions();

            var repo = LogManager.GetRepository() as Hierarchy;
            repo.Root.AddAppender(memAppender);
            repo.Configured = true;
            repo.RaiseConfigurationChanged(EventArgs.Empty);

            return new UnitTestLogger(LogManager.GetLogger("root"), memAppender);
        }

        [Test]
        [Ignore]
        public void TestDotNetFrameworkHarvester()
        {
            ConDep.Dsl.Logging.Logger.Initialize(CreateMemoryLogger());

            var executor = new PowerShellExecutor();
            var harvester = new ConDep.Dsl.Harvesters.DotNetFrameworkHarvester(executor);

            harvester.Harvest(new ServerConfig() {Name = "localhost", PowerShell = new PowerShellConfig(), DeploymentUser = new DeploymentUserConfig() {UserName = "admin", Password = "GrY,helene"} });
        }

        [Test]
        [Ignore]
        public void TestOSHarvester()
        {
            ConDep.Dsl.Logging.Logger.Initialize(CreateMemoryLogger());

            var executor = new PowerShellExecutor();
            var harvester = new ConDep.Dsl.Harvesters.OperatingSystemHarvester(executor);

            harvester.Harvest(new ServerConfig() { Name = "localhost", PowerShell = new PowerShellConfig(), DeploymentUser = new DeploymentUserConfig() { UserName = "admin", Password = "GrY,helene" } });
        }
    }
}
