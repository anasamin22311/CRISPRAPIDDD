import "package:flutter/material.dart";
Expanded buildAboutUs(final BuildContext context)
=> Expanded(
  child: GridView.count(
    childAspectRatio: 1/1.3,
    crossAxisCount: 2,
    // shrinkWrap: true,
    children: <Widget>[
      _buildUserItem(name: "Ibrahim\nElsaadany", role: "Flutter Developer"),
      _buildUserItem(name: "Anas Amin", role: "Web Developer"),
      _buildUserItem(name: "Anas Amin", role: "Web Developer"),
      _buildUserItem(name: "Anas Amin", role: "Web Developer"),
      _buildUserItem(name: "Anas Amin", role: "Web Developer"),
      _buildUserItem(name: "Anas Amin", role: "Web Developer"),
      _buildUserItem(name: "Anas Amin", role: "Web Developer"),
      _buildUserItem(name: "Anas Amin", role: "Web Developer"),
    ]
  ),
);

Column _buildUserItem({
  required final String name,
  required final String role
})=>Column(
  children: <Widget>[
    CircleAvatar(
      radius: 60.0,
      backgroundImage: NetworkImage(
        "https://buffer.com/cdn-cgi/image/w=1000,fit=contain,q=90,f=auto/library/content/images/size/w1200/2023/09/instagram-image-size.jpg",
      ),
    ),
    Text(
      name,
      textAlign: TextAlign.center,
      style: TextStyle(fontSize: 18.0)
    ),
    Text(
      role,
      textAlign: TextAlign.center
    )
  ],
);