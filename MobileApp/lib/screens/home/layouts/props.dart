import "package:flutter/material.dart";
import "../../../shared/components.dart";
Expanded buildProps(final BuildContext context)
=> Expanded(
  child: ListView(
    physics: BouncingScrollPhysics(),
    padding: const EdgeInsets.all(12.0),
    children: [
      Text(
        "Index",
        textAlign: TextAlign.center,
        style: TextStyle(fontSize: MediaQuery.of(context).size.width*0.08)
      ),
      buildButton(
        text: "Create New",
        func: (){}
      ),
      DataTable(
        columnSpacing: 30.0,
        headingRowColor: MaterialStatePropertyAll(Colors.grey[300]),
        columns: <DataColumn>[
          DataColumn(
            label: Text("Name")
          ),
          DataColumn(
            label: Text("Value")
          ),
          DataColumn(
            label: Text("DataSet")
          ),
          DataColumn(
            label: SizedBox()
          )
        ],
        rows: List.generate(15, (final int i)
        => DataRow(
          cells: List.generate(4, (final int j) => DataCell(_getCell(j+1)))
        ))
        )
    ],
  ),
);
Widget _getCell(final int j){
  if(j%4!=0)  return Text("AA");
  else return DropdownButton(
    padding: EdgeInsets.zero,
    hint: Text("Action"),
    items: <DropdownMenuItem>[
      DropdownMenuItem(
        value: 0,
        child: MaterialButton(
          minWidth: 80.0,
          color: Colors.blue[700],
          textColor: Colors.white,
          onPressed: (){},
          child: Text("Edit"),
        ),
      ),
      DropdownMenuItem(
        value: 1,
        child: MaterialButton(
          minWidth: 80.0,
          color: Colors.cyan,
          onPressed: (){},
          child: Text("Details"),
        ),
      ),
      DropdownMenuItem(
        value: 2,
        child: MaterialButton(
          minWidth: 80.0,
          color: Colors.red,
          textColor: Colors.white,
          onPressed: (){},
          child: Text("Delete")
        ),
      ),
    ],
    onChanged: (v){}
  );
}