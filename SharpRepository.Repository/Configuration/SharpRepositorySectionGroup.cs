﻿using System.Configuration;

namespace SharpRepository.Repository.Configuration
{
    public class SharpRepositorySectionGroup : ConfigurationSectionGroup, ISharpRepositoryConfiguration
    {
        [ConfigurationProperty("repositories", IsRequired = true)]
        public RepositoriesSectionGroup Repositories
        {
            get { return (RepositoriesSectionGroup)base.SectionGroups["repositories"]; }
        }

        [ConfigurationProperty("cachingStrategies")]
        public ConfigurationSectionGroup CachingStrategies
        {
            get { return SectionGroups["cachingStrategies"]; }
        }

        public IRepository<T, TKey> GetInstance<T, TKey>() where T : class, new()
        {
            return ConfigurationHelper.GetDefaultInstance<T, TKey>(Repositories);
        }
    }
}