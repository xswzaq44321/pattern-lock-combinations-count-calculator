using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1 {
	class Program {
		public static List<string> visited = new List<string>();
		public static List<List<string>> paths = new List<List<string>> {
			// this is a list of all possible linkable nodes of node 1 to 9
			// if ever see a string with two numbers, 
			// that means, for example, to get to 3 from 1, you must also cross 2,
			// here we called it "cross event"
				new List<string>{ "2", "4", "5", "6", "8", "23", "47", "59" },
				new List<string>{ "1", "3", "4", "5", "6", "7", "9", "58" },
				new List<string>{ "2", "4", "5", "6", "8", "21", "69", "57" },
				new List<string>{ "1", "2", "3", "5", "7", "8", "9", "56" },
				new List<string>{ "1", "2", "3", "4", "6", "7", "8", "9" },
				new List<string>{ "1", "2", "3", "5", "7", "8", "9", "54" },
				new List<string>{ "2", "4", "5", "6", "8", "41", "53", "89" },
				new List<string>{ "1", "3", "4", "5", "6", "7", "9", "52" },
				new List<string>{ "2", "4", "5", "6", "8", "63", "51", "87" },
		};

		static void Main(string[] args) {
			for(int i = 0; i < paths.Count(); ++i) {
				// from 4 nodes to 9 nodex maximum
				for(int j = 4; j <= 9; ++j) {
					dfs(1, new string((char)(i + '1'), 1), j);
				}
			}
			// remove all duplicate paths
			List<string> ans = visited.Distinct().ToList();
			System.Console.Write(ans.Count());
			System.Console.Read();
		}

		static void dfs(int layer, string tempPath, int maxNodes) {
			char at = tempPath.Last();
			// since array start at 0 and we count nodex from 1, we need to minus by 1
			int iat = at - '1';
			if(layer == maxNodes) {
				// remove duplicate characters before add to visited
				visited.Add(new string(tempPath.ToCharArray().Distinct().ToArray()));
				return;
			} else if(layer > maxNodes) {
				// might have a case that "accidentally" happened a cross event at last node,
				// and if so, it tends to exceed maxNodes
				return;
			}
			// try every possible linkable nodes of current node
			foreach(var item in paths[iat]) {
				// see if it's already linked
				if(!tempPath.Contains(item[item.Length - 1])) {
					// added tells us how much nodes this iteration added
					int added = item.Length;
					// see if it's a cross event, if so, deduce added by 1
					if(tempPath.Contains(item[0]))
						--added;
					dfs(layer + added, string.Copy(tempPath + item), maxNodes);
				}
			}
		}
	}
}
