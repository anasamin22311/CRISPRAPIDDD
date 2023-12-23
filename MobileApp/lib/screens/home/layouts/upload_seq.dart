import 'package:flutter/material.dart';
Column buildUpload(final BuildContext context)
=> Column(
  mainAxisAlignment: MainAxisAlignment.center,
  children: <Widget>[
    SizedBox(height: MediaQuery.of(context).size.height*0.03),
    Text(
      "Upload DNA Sequence",
      style: TextStyle(fontSize: MediaQuery.of(context).size.width*0.08)
    ),
    Card(
      child: Padding(
        padding: const EdgeInsets.all(12.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children:<Widget>[
            Text("Paste your DNA sequence:"),
            Padding(
              padding: EdgeInsets.symmetric(vertical:8.0),
              child: TextField(
                maxLines: 5,
                decoration: InputDecoration(
                  border: OutlineInputBorder()
                ),
              ),
            ),
            Text("\nOr upload a CSV or FASTA file:"),
            Row(
              children: <Widget>[
                MaterialButton(
                  color: Colors.grey[200],
                  onPressed: (){},
                  height: 30.0,
                  elevation: 0.0,
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(2.0),
                    side: BorderSide()
                  ),
                  child: Text("Choose File"),
                ),
                Text("   No file chosen")
              ],
            ),
            MaterialButton(
              color: Colors.blue,
              textColor: Colors.white,
              child: Text("Upload"),
              minWidth: double.infinity,
              onPressed: (){},
            )
          ]
        ),
      ),
    )
  ],
);