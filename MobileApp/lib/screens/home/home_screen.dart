import "package:crispr/screens/home/layouts/models.dart";
import "package:flutter/gestures.dart";
import "package:flutter/material.dart";
import "layouts/about_us.dart";
import "layouts/home_layout.dart";
import "layouts/upload_seq.dart";
import "layouts/props.dart";
class HomeScreen extends StatelessWidget{
  const HomeScreen({super.key});
  @override
  Scaffold build(final BuildContext context)
  => Scaffold(
    resizeToAvoidBottomInset: false,
    appBar: AppBar(
      title: const Text("CRISPR"),
      actions: <TextButton>[
        TextButton(
          child: Text("Register"),
          onPressed: (){}
        ),
        TextButton(
          child: Text("Login"),
          onPressed: (){},
        )
      ]
    ),
    drawer: NavigationDrawer(
      children: <ListTile>[
        ListTile(
          title: const Text("Home"),
          onTap: (){},
        ),
        ListTile(
          title: const Text("Upload Sequence"),
          onTap: (){},
        ),
        ListTile(
          title: const Text("About Us"),
          onTap: (){}
        ),
        ListTile(
          title: const Text("Models"),
          onTap: (){}
        ),
        ListTile(
          title: const Text("Data Sets"),
          onTap: (){},
        ),
        ListTile(
          title: const Text("Props"),
          onTap: (){}
        ),
        ListTile(
          title: const Text("Tags"),
          onTap: (){}
        ),
      ],
    ),
    body: Column(
      children: <Widget>[
        buildProps(context),
        const Divider(height: 0.0),
        Container(
          padding: EdgeInsets.only(left:30.0),
          alignment:Alignment.centerLeft,
          height: 40.0,
          width: double.infinity,
          child: RichText(
            text: TextSpan(
              style: TextStyle(color: Colors.grey),
              text:"© 2023 - CRISPR - ",
              children: <TextSpan>[
                TextSpan(
                  style: TextStyle(color: Colors.blue),
                  text: "Privacy",
                  recognizer: TapGestureRecognizer()..onTap = (){}
                )
              ]
            )
          ),
        )
      ],
    )
  );
}