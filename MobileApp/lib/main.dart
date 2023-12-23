import "package:flutter/material.dart";
import "screens/home/home_screen.dart";
void main(){
  runApp(const MyApp());
}
class MyApp extends StatelessWidget{
  const MyApp({super.key});
  @override
  MaterialApp build(final BuildContext context)
  => MaterialApp(
    theme: ThemeData(
      useMaterial3: false,
      scaffoldBackgroundColor: Colors.grey[200],
      appBarTheme: const AppBarTheme(
        color: Colors.white,
        foregroundColor: Colors.grey,
        titleTextStyle: TextStyle(
          color: Colors.black,
          fontSize:20.0
        ),
      ),
      textButtonTheme: TextButtonThemeData(
        style: TextButton.styleFrom(
          foregroundColor: Colors.black
        )
      )
    ),
    initialRoute: "home",
    routes: <String,StatelessWidget Function(BuildContext)>{
      "home": (final BuildContext context)=>const HomeScreen()
    },
  );
}