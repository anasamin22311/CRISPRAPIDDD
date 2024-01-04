import 'package:flutter/material.dart';
import '../../../shared/components.dart';
import '../../../shared/cubit/cubit.dart';
Expanded buildUpload(final BuildContext context, final AppCubit cubit)
=> Expanded(
  child: Column(
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
              const Text("Paste your DNA sequence:"),
              const Padding(
                padding: EdgeInsets.symmetric(vertical:8.0),
                child: TextField(
                  maxLines: 5,
                  decoration: InputDecoration(
                    border: OutlineInputBorder()
                  ),
                ),
              ),
              const Text("\nOr upload a CSV or FASTA file:"),
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
                    child: const Text("Choose File"),
                  ),
                  Text("   No file chosen")
                ],
              ),
              buildButton(
                text: "Upload",
                width: double.infinity,
                func: (){},
              )
            ]
          ),
        ),
      ),
      // SizedBox(height: double.infinity)
    ],
  ),
);