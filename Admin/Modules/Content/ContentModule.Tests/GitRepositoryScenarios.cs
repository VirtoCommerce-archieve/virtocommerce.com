using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentModule.Tests
{
    using Octokit;

    using Xunit;

    public class GitRepositoryScenarios
    {
        [Fact]
        public void Can_create_git_commit()
        {
            var client = new GitHubClient(new ProductHeaderValue("VirtoCommerce-ContentModule"), new Uri("https://github.com/"));
            client.Credentials = new Credentials("virtocommercecom","v1rtocommerce");

            var sometext = "asdasdljalskdj lasdjklasdk jls adjlkas djlksad";

            var list = client.Repository.GetAllBranches("VirtoCommerce", "virtocommerce.com").Result;
            var repositories = client.Repository.GetAllForUser("VirtoCommerce").Result;
            var commitsClient = client.Repository.Commits;

            var utf8Bytes = Encoding.UTF8.GetBytes("Hello World!");
            var base64String = Convert.ToBase64String(utf8Bytes);

            var blob = new NewBlob
            {
                Content = base64String,
                Encoding = EncodingType.Base64
            };

            var _owner = "VirtoCommerce";
            var repoName = "virtocommerce.com";

            var fixture = client.GitDatabase.Blob;
            var commintFixture = client.GitDatabase.Commit;
            var blobResult = fixture.Create(_owner, repoName, blob).Result;

            var newTree = new NewTree();
            newTree.Tree.Add(new NewTreeItem
            {
                Type = TreeType.Blob,
                Mode = FileMode.File,
                Path = "testfile.md",
                Sha = blobResult.Sha
            });

            var treeResult = client.GitDatabase.Tree.Create(_owner, repoName, newTree).Result;
            //client.GitDatabase.Tree.Get(_owner, repoName, )

            var newCommit = new NewCommit("test-commit2", treeResult.Sha);

            var commit = commintFixture.Create(_owner, repoName, newCommit).Result;
            Assert.NotNull(commit);

            var retrieved = fixture.Get(_owner, repoName, commit.Sha).Result;
            Assert.NotNull(retrieved);
        }

    }
}
