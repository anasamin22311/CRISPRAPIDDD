import "package:flutter/material.dart";
GridView buildAboutUs(final BuildContext context)
=> GridView.count(
  crossAxisCount: 2,
  shrinkWrap: true,
  children: <Widget>[
    Column(
      children: <Widget>[
        CircleAvatar(
          radius: 60.0,
          backgroundImage: NetworkImage(
            "https://buffer.com/cdn-cgi/image/w=1000,fit=contain,q=90,f=auto/library/content/images/size/w1200/2023/09/instagram-image-size.jpg",
            
            // fit: BoxFit.fill
          ),
        )
      ],
    ),
    Text("SSSSSSSSs")
  ]
);