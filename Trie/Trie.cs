namespace Trie
{
    public class Trie
    {
        private TrieNode treeRoot;

        public Trie()
        {
            treeRoot = new TrieNode('*');
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            treeRoot.Add(word);
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            return treeRoot.Contains(word);
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            return treeRoot.StartsWith(prefix);
        }
    }
}
