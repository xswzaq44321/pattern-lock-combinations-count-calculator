using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1 {
	class Program {
		public static List<string> visited = new List<string>();
		public static List<List<string>> paths = new List<List<string>> {
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
				dfs(1, new string((char)(i + '1'), 1));
			}
			System.Console.Write(visited.Count());
			System.Console.Read();
		}

		static void dfs(int layer, string tempPath = "") {
			char at = tempPath.Last();
			int iat = at - '1';
			if(layer == 9) {
				visited.Add(new string(tempPath.ToCharArray().Distinct().ToArray()));

				return;
			}
			foreach(var item in paths[iat]) {
				if(!tempPath.Contains(item[item.Length - 1])) {
					dfs(layer + 1, string.Copy(tempPath + item));
				}
			}
		}
	}
}
