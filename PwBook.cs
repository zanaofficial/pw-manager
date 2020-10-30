using System;
using System.Collections.Generic;


class PwBook {
  List<Pw> pws;

  public PwBook() {
    pws = new List<Pw>();
  }

  public bool add(string seite, string pw) {
    Pw pwr = new Pw(seite, pw);
    Pw result = find(seite);

    if (result == null) {
      pws.Add(pwr);
      return true;
    } else {
      return false;
    }
  }

  public bool remove(string seite) {
    Pw pwr = find(seite);

    if (pwr != null) {
      pws.Remove(pwr);
      return true;
    } else {
      return false;
    }
  }

  public void list(Action<Pw> action) {
    pws.ForEach(action);
  }

  public bool isEmpty() {
    return (pws.Count == 0);
  }

  public Pw find(string seite) {
    Pw pwr = pws.Find(
      delegate(Pw a) {
        return a.seite == seite;
      }
    );
    return pwr;
  }
}
