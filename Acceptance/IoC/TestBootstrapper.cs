using System;
using System.IO;
using System.Linq;
using Nancy;

namespace Acceptance.IoC
{
    public class TestBootstrapper : DefaultNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider
        {
            get { return new CustomRootPathProvider(); }
        }
    }

    public class CustomRootPathProvider : IRootPathProvider
    {
        private static string _cachedRootPath;

        public string GetRootPath()
        {
            if (!string.IsNullOrEmpty(_cachedRootPath))
                return _cachedRootPath;

            var currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);

            bool rootPathFound = false;
            while (!rootPathFound)
            {
                var directoriesContainingViewFolder = currentDirectory.GetFiles("*.cshtml", SearchOption.AllDirectories);
                if (directoriesContainingViewFolder.Any())
                {
                    _cachedRootPath = directoriesContainingViewFolder.First().DirectoryName;
                    rootPathFound = true;
                }

                currentDirectory = currentDirectory.Parent;
            }

            return _cachedRootPath;
        }
    }
}