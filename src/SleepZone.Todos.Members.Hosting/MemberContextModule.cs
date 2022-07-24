﻿using Autofac;
using MDP;
using MDP.Hosting;
using Microsoft.Extensions.Configuration;
using SleepZone.Todos.Members.Mocks;
using System;

namespace SleepZone.Todos.Members.Hosting
{
    public class MemberContextModule : MDP.Hosting.Module
    {
        // Methods
        protected override void ConfigureContainer(ContainerBuilder container)
        {
            #region Contracts

            if (container == null) throw new ArgumentException(nameof(container));

            #endregion

            // MemberContext
            container.RegisterFactory<MemberContext, MemberContextFactory>(this.Configuration).SingleInstance();

            // MemberRepository
            container.RegisterFactory<MemberRepository, MockMemberRepositoryFactory>(this.Configuration);
        }
    }
}