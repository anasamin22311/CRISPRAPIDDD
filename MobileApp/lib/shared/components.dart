import "package:flutter/material.dart";
MaterialButton buildButton({
  required final String text,
  required final void Function() func,
  final double? width
})
=> MaterialButton(
  color: Colors.blue,
  textColor: Colors.white,
  onPressed: func,
  minWidth: width,
  child: Text(text)
);