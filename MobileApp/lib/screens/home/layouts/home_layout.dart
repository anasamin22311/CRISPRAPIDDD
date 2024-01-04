import "package:flutter/material.dart";
import "package:flutter/gestures.dart";
import "package:url_launcher/url_launcher.dart";
import "../../../shared/cubit/cubit.dart";
Padding buildHome(final BuildContext context,final AppCubit cubit)
=> Padding(
  padding: const EdgeInsets.all(8.0),
  child: Column(
    mainAxisAlignment: MainAxisAlignment.center,
    children: <Widget>[
      Text(
        "Welcome to\nLungCancerDetect!",
        textAlign: TextAlign.center,
        style: TextStyle(
          fontSize: MediaQuery.of(context).size.width*0.1,
        )
      ),
      RichText(
        textAlign: TextAlign.center,
        text: TextSpan(
          style: TextStyle(
            color: Colors.black,
            fontSize:MediaQuery.of(context).size.height*0.023
          ),
          text: """
  
  LungCancerDetect is a cutting-edge website that leverages machine learning and CRISPR technology to detect and treat lung cancer.
  
  Our advanced algorithms analyze medical data using state-of-the-art machine learning techniques, enabling us to identify potential lung cancer cases with high accuracy.
  
  With the power of CRISPR, we aim to revolutionize lung cancer treatment by developing precise gene-editing solutions. Our platform provides a streamlined and efficient process for administering targeted therapies.
  
  In addition to our core features, we also offer a range of supplementary resources to support our users. Explore our """,
          children: [
            TextSpan(
              text: "Kaggle page",
              style: TextStyle(color: Colors.blue),
              recognizer: TapGestureRecognizer()..onTap = ()=>launchUrl(
                Uri(
                  scheme: "https",
                  host: "kaggle.com"
                ),
                mode: LaunchMode.inAppWebView
              )
            ),
            TextSpan(
              text: """, where you can access datasets, collaborate with others, and participate in data science competitions.
  
  Join us in the fight against lung cancer and discover how technology is transforming the field of oncology."""
            )
          ]
        )
      )
    ]
  ),
);