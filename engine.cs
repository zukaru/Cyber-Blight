namespace CyberBlight.engine 
{

    using System.Collections.Generic;
    using System.Linq;
    using System;
    using System.Threading;

    public class Logic 
    {
            public static string focus = "console_main_menu";


    }
    
    
    public class engine
    {
        // these functions should be used throughout the project to automate
        // repetetive or complex tasks.
        // this is the 'engine' of our game.


        public static void slow_type(string text, int typing_speed = 50, bool new_line = true)
        {
        // print function that feels like a human is typing.
        //
        //typing_speed is an integer that equals words per minute.
        //
        //new_line is a boolean, it controls weather the console will begin 
        //the next print operation on the same line or a new line.
            foreach (var letter in text)
            {
            //this looks at each letter and prints it, then waits a random amount of time.
                Console.Write(letter);
                //sys.stdout.flush();
                Random rng = new Random();
                Thread.Sleep(Convert.ToInt32(rng.NextDouble() * 10.0 / typing_speed));
            }
            if (new_line)
            {
                Console.WriteLine("");
            }
        }

        public static object drop_down(string prompt,Dictionary<string,string> items, string input_prompt = ">")
        {

            /* makes a drop down menu from a dict of choices

             returns: a value from the dict passed into it,
             there is no way to exit this menu loop without a valid selection.

             if you want to add an exit clause, than make an exit value 
             in your dict to be returned and then handle that return value
             from your calling code.

             example:

             selection=drop_down(prompt,items={},input_prompt='>')
             if selection == exit_value:
                 break

             input_prompt defaults to a single '>'
             it is recommended to modify this to show how many menus
             deep a player is.

             if the input is not recognized too many times the menu 
             prompt will be re-printed to prevent the player from having to
             scroll up to read the available options.

             input will be valid if a key from the dict is typed out in upper
             or lowercase, or if the index of the menu item is input
            */

            object item;
            int index;
            Console.WriteLine(prompt + ":");
            foreach (var _tup_1 in items.Select((_p_1,_p_2) => Tuple.Create(_p_2, _p_1)))
            {
                index = _tup_1.Item1;
                item = _tup_1.Item2;
                Console.WriteLine($"[{index+1}] {item}");
            }
            int typo = 0;
            while (true)
            {
                if (typo == 4)
                {
                    typo = 0;
                    Console.WriteLine("\n" + prompt + ":");
                    foreach (var _tup_2 in items.Select((_p_3,_p_4) => Tuple.Create(_p_4, _p_3)))
                    {
                        index = _tup_2.Item1;
                        item = _tup_2.Item2;
                        Console.WriteLine($"[{index+1}] {item}");
                    }
                }
                Console.Write(input_prompt);
                var input = Console.ReadLine();
                try
                {
                    int selection = Convert.ToInt32(input) - 1;
                    foreach (var _tup_3 in items.Select((_p_5,_p_6) => Tuple.Create(_p_6, _p_5)))
                    {
                        index = _tup_3.Item1;
                        item = _tup_3.Item2;
                        if (index == selection)
                        {
                            return items[Convert.ToString(selection)];
                        }
                    }
                }
                catch (ArgumentException)
                {
                    if(input!=null)
                    {
                        string selection = char.ToUpper(input[0]) + input.Substring(1);
                        if (items.ContainsKey(selection))
                        {
                            return items[selection];
                        }
                    }
                }
                Console.WriteLine("\nThat is not on the list.\nVerify your selection.");
                typo += 1;
            }
        }

        public static string drop_down_string(string prompt,Dictionary<string,string> items, string input_prompt = ">")
        {

            /* makes a drop down menu from a dict of choices

             returns: a value from the dict passed into it,
             there is no way to exit this menu loop without a valid selection.

             if you want to add an exit clause, than make an exit value 
             in your dict to be returned and then handle that return value
             from your calling code.

             example:

             selection=drop_down(prompt,items={},input_prompt='>')
             if selection == exit_value:
                 break

             input_prompt defaults to a single '>'
             it is recommended to modify this to show how many menus
             deep a player is.

             if the input is not recognized too many times the menu 
             prompt will be re-printed to prevent the player from having to
             scroll up to read the available options.

             input will be valid if a key from the dict is typed out in upper
             or lowercase, or if the index of the menu item is input
            */

            object item;
            int index;
            Console.WriteLine(prompt + ":");
            foreach (var _tup_1 in items.Select((_p_1,_p_2) => Tuple.Create(_p_2, _p_1)))
            {
                index = _tup_1.Item1;
                item = _tup_1.Item2;
                Console.WriteLine($"[{index+1}] {item}");
            }
            int typo = 0;
            while (true)
            {
                if (typo == 4)
                {
                    typo = 0;
                    Console.WriteLine("\n" + prompt + ":");
                    foreach (var _tup_2 in items.Select((_p_3,_p_4) => Tuple.Create(_p_4, _p_3)))
                    {
                        index = _tup_2.Item1;
                        item = _tup_2.Item2;
                        Console.WriteLine($"[{index+1}] {item}");
                    }
                }
                Console.Write(input_prompt);
                var input = Console.ReadLine();
                try
                {
                    int selection = Convert.ToInt32(input) - 1;
                    foreach (var _tup_3 in items.Select((_p_5,_p_6) => Tuple.Create(_p_6, _p_5)))
                    {
                        index = _tup_3.Item1;
                        item = _tup_3.Item2;
                        if (index == selection)
                        {
                            return items[Convert.ToString(selection)];
                        }
                    }
                }
                catch (ArgumentException)
                {
                    if(input!=null)
                    {
                        string selection = char.ToUpper(input[0]) + input.Substring(1);
                        if (items.ContainsKey(selection))
                        {
                            return items[selection];
                        }
                    }
                }
                Console.WriteLine("\nThat is not on the list.\nVerify your selection.");
                typo += 1;
            }
        }
        public static void clear_console()
        {
        // removes all text from the console preventing scrolling up
            Console.Clear();
            Console.WriteLine("\n\n");
        }

        public static void jump(int amount = 1)
        {
        /* prints new lines

            new lines are blank spaces between the last thing printed and the next.
            enter an amount of lines to skip. defaults to 1
        */
            for(int i = 0; i < amount; i++)
            {
                Console.WriteLine("\n");
            }
        }
    }
}