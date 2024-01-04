import "package:flutter/material.dart";
import "../../../shared/cubit/cubit.dart";
Expanded buildAboutUs(final BuildContext context,final AppCubit cubit)
=> Expanded(
  child: Column(
    mainAxisAlignment: MainAxisAlignment.spaceAround,
    children: <Widget>[
      _buildUserItem(
        0,
        cubit,
        name: "Ibrahim Elsaadany",
        role: "Flutter Developer",
        details: "Developed the mobile app,\nparticipated in documentation."
      ),
      _buildUserItem(
        1,
        cubit,
        name: "Anas Amin",
        role: "Full Stack Developer",
        details: "Developed the API,\nparticipated in documentation."
      ),
    ]
  ),
);

InkWell _buildUserItem(
  final int i,
  final AppCubit cubit,
  {
  required final String name,
  required final String role,
  required final String details
})=>InkWell(
  onTap: ()=>cubit.toggleU(i),
  borderRadius: BorderRadius.circular(12.0),
  child: Padding(
    padding: const EdgeInsets.all(8.0),
    child: Column(
      children: <Widget>[
        CircleAvatar(
          radius: 80.0,
          backgroundImage: NetworkImage(
            "https://buffer.com/cdn-cgi/image/w=1000,fit=contain,q=90,f=auto/library/content/images/size/w1200/2023/09/instagram-image-size.jpg",
          ),
        ),
        Text(
          name,
          textAlign: TextAlign.center,
          style: const TextStyle(
            fontSize: 22.0,
            fontWeight: FontWeight.bold
          )
        ),
        Text(
          role,
          textAlign: TextAlign.center,
          style: const TextStyle(fontSize: 18.0),
        ),
        if(cubit.showUDetails[i])
        Text(
          details,
          textAlign: TextAlign.center,
        )
      ],
    ),
  ),
);