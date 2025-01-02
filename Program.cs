using System;
using System.IO;

namespace save_load {
    class Program {
        public static string default_path = "def_file.txt";
        public static string loadFile(string dir_path) {
            string[] txtFiles = Directory.GetFiles(dir_path, "*.txt");
            foreach (string file in txtFiles) {
                if (file == Path.Combine(dir_path, default_path)) {
                    return File.ReadAllText(default_path);
                }
            }
            return string.Empty;
        }
        public static void saveFile(string content) {
            File.WriteAllText(default_path, content);
        }
        static void Main() {
            string a = "a";
            saveFile(a);

            while (true) {
                string opt = Console.ReadLine();
                if (opt.StartsWith('-')) {
                    switch (opt[1]) {
                        case 'r': //read
                            Console.WriteLine($"{default_path}\n-------\n\n");
                            string loadContent = loadFile(Directory.GetCurrentDirectory());
                            Console.WriteLine(loadContent);
                            Console.WriteLine("\n\n-------");
                            break;
                        case 'w': //write
                            if (opt.Length > 3) {
                                string content = opt.Substring(4);
                                string[] contents = content.Split(new[] { "\\n" }, StringSplitOptions.None);
                                string processed_content = string.Join(Environment.NewLine, contents);

                                if (opt[2] == 'a') {
                                    File.AppendAllText(default_path, processed_content);
                                } else if (opt[2] == 'o') {
                                    File.WriteAllText(default_path, processed_content);
                                } else {
                                    Console.WriteLine("-wa or -wo then the context.");
                                }
                            } else {
                                Console.WriteLine("Please provide us a content.");
                            }
                            break;
                        default: //none of above
                            Console.WriteLine("I suggest you to -r or -w");
                            break;
                    }
                }
                Console.WriteLine("\nPress ENTER to continue");
                Console.ReadKey();
                Console.Clear();

                return;
            }
        }
    }
}
