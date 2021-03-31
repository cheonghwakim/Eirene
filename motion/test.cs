using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        // Debug.Log(reference);
        FirebaseDatabase.DefaultInstance
          .GetReference("message")
          .GetValueAsync().ContinueWith(task => {
              if (task.IsFaulted)
              {
                  // Handle the error...
              }
              else if (task.IsCompleted)
              {
                  DataSnapshot snapshot = task.Result;
                  // Do something with snapshot...
                  // Debug.Log(snapshot);
                  foreach (DataSnapshot data in snapshot.Children)
                  {

                      IDictionary message = (IDictionary)data.Value;
                      Debug.Log(message["status"]);
                      

                  }
              }
          });
        var ref = FirebaseDatabase.DefaultInstance
                        .GetReference("message");
        ref.ChildChanged += HandleChildChanged;
    }   

    void HandleChildChanged(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // Do something with the data in args.Snapshot
        Debug.Log("really?");
    }
}
