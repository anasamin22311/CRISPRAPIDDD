import "package:flutter/gestures.dart";
import "package:flutter/material.dart";
import "package:flutter_bloc/flutter_bloc.dart";
import "../../shared/cubit/cubit.dart";
import "../../shared/cubit/states.dart";
import "layouts/about_us.dart";
import "layouts/home_layout.dart";
import "layouts/upload_seq.dart";
import "layouts/models.dart";
import "layouts/props.dart";
class HomeScreen extends StatelessWidget{
  final List<Widget Function(BuildContext,AppCubit)> _layouts=[
    buildHome, buildUpload, buildAboutUs, buildModels,
    buildProps,
  ];
  HomeScreen({super.key});
  @override
  Widget build(final BuildContext context)
  => BlocProvider<AppCubit>(
    create: (final BuildContext context)=>AppCubit(),
    child: BlocBuilder<AppCubit,AppStates>(
      builder: (final BuildContext context,final AppStates state) {
        final AppCubit cubit = BlocProvider.of<AppCubit>(context);
        return Scaffold(
          resizeToAvoidBottomInset: false,
          appBar: AppBar(
            title: const Text("CRISPR"),
            actions: <TextButton>[
              TextButton(
                child: const Text("Register"),
                onPressed: (){}
              ),
              TextButton(
                child: const Text("Login"),
                onPressed: (){},
              )
            ]
          ),
          drawer: NavigationDrawer(
            children: <ListTile>[
              ListTile(
                title: const Text("Home"),
                onTap: (){
                  cubit.changeLayout(0);
                  Navigator.of(context).pop();
                },
              ),
              ListTile(
                title: const Text("Upload Sequence"),
                onTap: (){
                  cubit.changeLayout(1);
                  Navigator.of(context).pop();
                },
              ),
              ListTile(
                title: const Text("About Us"),
                onTap: (){
                  cubit.changeLayout(2);
                  Navigator.of(context).pop();
                }
              ),
              ListTile(
                title: const Text("Models"),
                onTap: (){
                  cubit.changeLayout(3);
                  Navigator.of(context).pop();
                }
              ),
              ListTile(
                title: const Text("Data Sets"),
                onTap: (){
                  cubit.changeLayout(4);
                  Navigator.of(context).pop();
                },
              ),
              ListTile(
                title: const Text("Props"),
                onTap: (){
                  cubit.changeLayout(5);
                  Navigator.of(context).pop();
                }
              ),
              ListTile(
                title: const Text("Tags"),
                onTap: (){
                  cubit.changeLayout(6);
                  Navigator.of(context).pop();
                }
              ),
            ],
          ),
          body: Column(
            children: <Widget>[
              _layouts[cubit.currentLayout](context,cubit),
              const Divider(height: 0.0),
              Container(
                padding: const EdgeInsets.only(left:30.0),
                alignment:Alignment.centerLeft,
                height: 40.0,
                width: double.infinity,
                child: RichText(
                  text: TextSpan(
                    style: const TextStyle(color: Colors.grey),
                    text:"© 2023 - CRISPR - ",
                    children: <TextSpan>[
                      TextSpan(
                        style: const TextStyle(color: Colors.blue),
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
    ),
  );
}