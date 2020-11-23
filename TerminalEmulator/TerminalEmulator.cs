using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TerminalEmulator
{
    public class TerminalEmulator
    {
        private Catalog users;
        private Catalog enable;
        private Catalog config;

        public TerminalEmulator()
        {
            DirectoryInitializer();
        }


        private void DirectoryInitializer()
        {
            UserListCommand();
            EnableListCommand();
            ConfigListCommand();
        }
        private void UserListCommand()
        {
            users = new Catalog("User");
            users.AddCommand("time", () => Console.WriteLine(DateTime.Now));
            users.AddCommand("enable", () => enable.Operation());
        }
        private void EnableListCommand()
        {
            enable = new Catalog("Enable", users.path);
            enable.AddCommand("config", () => config.Operation());

        }
        private void ConfigListCommand()
        {
            config = new Catalog("Config", enable.path);
            config.AddCommand("colorgreen", () => Console.ForegroundColor = ConsoleColor.Green);
        }
        public void RunningTerminal() { users.Operation(); }


    }

}
