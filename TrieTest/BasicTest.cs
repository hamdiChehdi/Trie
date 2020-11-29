namespace TrieTest
{
    using Xunit;
    using Trie;

    public class BasicTest
    {
        [Fact]
        public void SimpleSenarioTest()
        {
            var trie = new Trie();
            trie.Insert("apple");

            Assert.True(trie.Search("apple"));
            Assert.False(trie.Search("app"));
            Assert.True(trie.StartsWith("app"));

            trie.Insert("app");
            Assert.True(trie.Search("app"));
        }
    }
}
