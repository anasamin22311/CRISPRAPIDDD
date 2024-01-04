import 'package:flutter/material.dart';
import '../../../shared/components.dart';
import '../../../shared/cubit/cubit.dart';
Expanded buildModels(final BuildContext context, final AppCubit cubit)
=> Expanded(
  child: ListView(
    physics: BouncingScrollPhysics(),
    padding: const EdgeInsets.all(8.0),
    children: [
      Text(
        "Models",
        textAlign: TextAlign.center,
        style: TextStyle(fontSize: MediaQuery.of(context).size.width*0.08)
      ),
      Padding(
        padding: const EdgeInsets.symmetric(horizontal:4.0),
        child: buildButton(
          text: "Create New",
          func: (){}
        ),
      ),
      ...List.filled(8, _buildModelItem())
    ],
  ),
);
InkWell _buildModelItem()
=> InkWell(
  borderRadius: BorderRadius.circular(5.0),
  onTap: (){},
  child: Card(
    shape: RoundedRectangleBorder(
      side: const BorderSide(color: Colors.grey),
      borderRadius: BorderRadius.circular(5.0)
    ),
    child: Padding(
      padding: const EdgeInsets.all(12.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: <Widget>[
          Text(
            "Bla Blob Bli sdasdsasadads",
            textAlign: TextAlign.center,
            style: TextStyle(
              color: Colors.blue[700],
              fontSize:20.0,
              fontWeight: FontWeight.bold,
            )
          ),
          Text(
            "dsd cancer sddsd\n\n",
            style: TextStyle(color: Colors.grey)
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: <Widget>[
              Text(
                "Reference\nAccuracy: 32",
                style: TextStyle(color: Colors.grey),
              ),
              Spacer(),
              InkWell(
                onTap: (){},
                child: Text(
                  "Repository",
                  style: TextStyle(
                    decoration: TextDecoration.underline,
                    color: Colors.blue
                  ),
                ),
              )
            ],
          ),
        ],
      ),
    ),
  ),
);