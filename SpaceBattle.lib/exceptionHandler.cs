namespace SpaceBattle.lib;
using System.Collections.Generic;
using System;
public class exceptionHandler 
{

    private Dictionary <string, Dictionary <string, ICommand >> tree1;
    private Dictionary <string, Dictionary <string, ICommand >> tree2;
    private class Fallback: ICommand
        {
            void еxecute()
            {
                throw new KeyNotFoundException();
            }
        }
    public exceptionHandler()
    {
        tree1 = new Dictionary <string, Dictionary <string, ICommand >> () ;
        tree2 = new Dictionary <string, Dictionary <string, ICommand >> () ;
        tree2.Add("Any", new Dictionary<string, ICommand>());
        tree2.Add("Default", new Dictionary<string, ICommand>());
        tree2["Default"].Add("Fallback", new Fallback());
    }
    public void Handl(string key, Exception exc)
    {
        ICommand command;
        string tipe = exc.GetType();
        if(tree1.ContainsKey(Key) && tree1[Key].ContainsKey(tipe))
        {
            command = tree1[Key][Type];
        }
        else if(tree2["Any"].ContainsKey(tipe))
        {
            command =tree2["Any"][tipe];
        }
        else if(tree2["Default"].ContainsKey(Key))
        {
            command =tree2["Default"][Key];
        }
        else
        {
            command =tree2["Default"]["Fallback"];
        }
        command Execute();
    }
     public void Add(string key, Exception exc, ICommand command)
     {
        if(!tree1.ContainsKey(Key))
        {
            tree1.Add(key, new Dictionary <string, ICommand >() );
        }
        string exceptionName = exc.GetType().ToString();
        tree1[Key].Add(exceptionName, command);
     }
     public void AddDefault(string key, ICommand command)
     {
        if(!tree2["Default"].ContainsKey(Key))
        {
            tree2.Add(key, new Dictionary <string, ICommand >() );
        }
        tree2["Default"].Add(Key, command);
     }
     public void AddAny(Exception exc, ICommand command)
     {
        if(!tree2["Any"].ContainsKey(exc.GetType().ToString()))
        {
            tree2.Add(exc.GetType().ToString(), new Dictionary <string, ICommand >() );
        }
         tree2["Ane"].Add(exc.GetType().ToString(), command);
     }
     public void AddFallback(ICommand command)
     {
        tree2["Default"]["Fallback"] = command;
     }
}