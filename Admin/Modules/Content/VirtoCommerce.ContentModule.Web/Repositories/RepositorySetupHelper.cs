using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace VirtoCommerce.ContentModule.Web.Repositories
{
    public static class RepositorySetupHelper
    {
        public static async Task<TreeResponse> CreateTree(this IGitHubClient client, Repository repository, string treeSha, IEnumerable<KeyValuePair<string, string>> treeContents)
        {
            var collection = new List<NewTreeItem>();

            foreach (var c in treeContents)
            {
                var baselineBlob = new NewBlob
                {
                    Content = c.Value,
                    Encoding = EncodingType.Utf8
                };

                //new Blob() {}

                // Try getting an exisiting blob first

                var baselineBlobResult = await client.GitDatabase.Blob.Create(repository.Owner.Login, repository.Name, baselineBlob);

                collection.Add(new NewTreeItem
                {
                    Type = TreeType.Blob,
                    Mode = FileMode.File,
                    Path = c.Key,
                    Sha = baselineBlobResult.Sha
                });
            }

            var newTree = new NewTree { Tree = collection, BaseTree = treeSha};

            return await client.GitDatabase.Tree.Create(repository.Owner.Login, repository.Name, newTree);
        }

        public static async Task<Commit> CreateCommit(this IGitHubClient client, Repository repository, string message, string sha, string parent)
        {
            var newCommit = new NewCommit(message, sha, parent);
            return await client.GitDatabase.Commit.Create(repository.Owner.Login, repository.Name, newCommit);
        }

        public static async Task<DirectoryContent[]> GetRootFolders(this IGitHubClient client, Repository repository)
        {
            var directories = await client.Repository.Contents.GetRoot(repository.Owner.Login, repository.Name);
            return directories.ToArray();

            //var master = await client.GitDatabase.Reference.Get(repository.Owner.Login, repository.Name, "heads/master");

            //return await client.GitDatabase.Tree.Get(repository.Owner.Login, repository.Name, master.Object.Sha);

        }

        public static async Task<DirectoryContent[]> GetFiles(this IGitHubClient client, Repository repository, string path)
        {
            var directories = await client.Repository.Contents.GetForPath(repository.Owner.Login, repository.Name, path);
            return directories.ToArray();
        }

        public static async Task<Reference> SaveFiles(this IGitHubClient client, Repository repository, string comment, IEnumerable<KeyValuePair<string, string>> treeContents)
        {
            var master = await client.GitDatabase.Reference.Get(repository.Owner.Login, repository.Name, "heads/master");

            var baseTree = await client.GitDatabase.Tree.Get(repository.Owner.Login, repository.Name, master.Object.Sha);

            // create new commit for master branch
            var newMasterTree = await client.CreateTree(repository, baseTree.Sha, treeContents);
            var newMaster = await client.CreateCommit(repository, comment, newMasterTree.Sha, master.Object.Sha);

            // update master
            return await client.GitDatabase.Reference.Update(repository.Owner.Login, repository.Name, "heads/master", new ReferenceUpdate(newMaster.Sha));

            /*
            // create new commit for feature branch
            var featureBranchTree = await client.CreateTree(repository, new Dictionary<string, string> { { "README.md", "I am overwriting this blob with something new" } });
            var featureBranchCommit = await client.CreateCommit(repository, "this is the commit to merge into the pull request", featureBranchTree.Sha, newMaster.Sha);

            // create branch
            return await client.GitDatabase.Reference.Create(repository.Owner.Login, repository.Name, new NewReference("refs/heads/my-branch", featureBranchCommit.Sha));
        
             **/
        }

    }
}
