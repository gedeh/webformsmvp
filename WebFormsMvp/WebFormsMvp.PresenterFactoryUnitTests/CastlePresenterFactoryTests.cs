﻿using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebFormsMvp.Binder;
using WebFormsMvp.Castle;

namespace WebFormsMvp.PresenterFactoryUnitTests
{
    [TestClass]
    public class CastlePresenterFactoryTests : PresenterFactoryTests
    {
        protected override IPresenterFactory BuildFactory()
        {
            var container = new WindsorContainer();

            foreach (var type in TypesThatShouldBeRegistered)
                container.Register(Component.For(type).ImplementedBy(type).LifeStyle.Transient);

            var kernel = container.Kernel;
            return new CastlePresenterFactory(kernel);
        }
    }
}