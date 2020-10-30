using System;
using System.Collections.Generic;

class PwPrompt {
  PwBook book;

  public PwPrompt() {
    book = new PwBook();
  }

  static void Main(string[] args) {
    string selection = "";
    PwPrompt prompt = new PwPrompt();

    prompt.displayMenu();
    while (!selection.ToUpper().Equals("Q")) {
      Console.WriteLine("Selection: ");
      selection = Console.ReadLine();
      prompt.performAction(selection);
    }
  }

  void displayMenu() {
    Console.WriteLine("Main Menu");
    Console.WriteLine("=========");
    Console.WriteLine("A - Add an Address");
    Console.WriteLine("D - Delete an Address");
    Console.WriteLine("E - Edit an Address");
    Console.WriteLine("L - List All Addresses");
    Console.WriteLine("Q - Quit");
  }

  void performAction(string selection) {
    string seite = "";
    string pw = "";

    switch (selection.ToUpper()) {
      case "A":
        Console.WriteLine("Enter Name: ");
        seite = Console.ReadLine();
        Console.WriteLine("Enter Address: ");
        pw = Console.ReadLine();
        if (book.add(seite, pw)) {
          Console.WriteLine("Address successfully added!");
        } else {
          Console.WriteLine("An address is already on file for {0}.", seite);
        }
        break;
      case "D":
        Console.WriteLine("Enter Name to Delete: ");
        seite = Console.ReadLine();
        if (book.remove(seite)) {
          Console.WriteLine("Address successfully removed");
        } else {
          Console.WriteLine("Address for {0} could not be found.", seite);
        }
        break;
      case "L":
        if (book.isEmpty()) {
          Console.WriteLine("There are no entries.");
        } else {
          Console.WriteLine("Addresses:");
          book.list(
            delegate(Pw a) {
              Console.WriteLine("{0} - {1}", a.seite, a.pw);
            }
          );
        }
        break;
      case "E":
        Console.WriteLine("Enter Name to Edit: ");
        seite = Console.ReadLine();
        Pw pwr = book.find(seite);
        if (pwr == null) {
          Console.WriteLine("Address for {0} count not be found.", seite);
        } else {
          Console.WriteLine("Enter new Address: ");
          pwr.pw = Console.ReadLine();
          Console.WriteLine("Address updated for {0}", seite);
        }
        break;
    }
  }
}