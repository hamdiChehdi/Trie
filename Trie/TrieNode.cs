namespace Trie
{
    using System.Collections.Generic;

    public class TrieNode
    {
        public bool IsEndWord;
        public char Letter;
        public Dictionary<char, TrieNode> Children;

        public TrieNode(char letter)
        {
            Letter = letter;
            Children = new Dictionary<char, TrieNode>();
        }

        public void Add(string word)
        {
            (int lastIndex, TrieNode lastNode) = LastCommonTrie(word);

            // The worl already exist in the Trie
            if (lastIndex == word.Length)
            {
                lastNode.IsEndWord = true;
                return;
            }

            lastNode.AddNewWord(word, lastIndex);
        }


        public bool StartsWith(string word)
        {
            return Contains(word, true);
        }

        public bool Contains(string word)
        {
            return Contains(word, false);
        }

        private bool Contains(string word, bool isPrefix)
        {
            var currentNode = this;

            for (int i = 0; i < word.Length; i++)
            {
                if (currentNode.ChildNotExist(word[i]))
                {
                    return false;
                }

                currentNode = currentNode.GetChild(word[i]);
            }

            return isPrefix || currentNode.IsEndWord;
        }

        private (int, TrieNode) LastCommonTrie(string word)
        {
            var currentNode = this;
            int index = 0;

            // find common Trie between the word and the Trie
            for (; index < word.Length; index++)
            {
                if (currentNode.ChildNotExist(word[index]))
                {
                    break;
                }

                currentNode = currentNode.GetChild(word[index]);
            }

            return (index, currentNode);
        }

        private void AddNewWord(string word, int startIndex)
        {
            TrieNode parent = this;

            for (int i = startIndex; i < word.Length; i++)
            {
                TrieNode newNode = new TrieNode(word[i]);
                parent.AddChild(newNode);
                parent = newNode;
            }

            parent.IsEndWord = true;
        }

        private bool ChildNotExist(char c) => !Children.ContainsKey(c);
        private TrieNode GetChild(char c) => Children[c];
        private void AddChild(TrieNode child) => Children.Add(child.Letter, child);
    }
}
