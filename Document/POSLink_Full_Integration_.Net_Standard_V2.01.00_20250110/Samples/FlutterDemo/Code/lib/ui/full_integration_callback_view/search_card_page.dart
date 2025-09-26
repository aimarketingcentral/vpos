/*
 * ===========================================================================================
 * = COPYRIGHT
 *          PAX Computer Technology (Shenzhen) Co., Ltd. PROPRIETARY INFORMATION
 *   This software is supplied under the terms of a license agreement or nondisclosure
 *   agreement with PAX Computer Technology (Shenzhen) Co., Ltd. and may not be copied or
 *   disclosed except in accordance with the terms in that agreement.
 *     Copyright (C) 2023 PAX Computer Technology (Shenzhen) Co., Ltd. All rights reserved.
 * ===========================================================================================
 */

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:poslink2/model/method_channel.dart';

import '../../model/event_channel.dart';
import '../../res/colors.dart';

class SearchCardPage extends StatefulWidget {
  bool swipe;
  bool insert;
  bool tap;
  bool keyin;
  final double amount;
  final bool outInput;
  final int minAccountLength;
  final int maxAccountLength;

  SearchCardPage({
    this.swipe = false,
    this.insert = false,
    this.tap = false,
    this.keyin = false,
    this.amount = 0.0,
    this.outInput = false,
    this.minAccountLength = 10,
    this.maxAccountLength = 19,
  });

  @override
  State<StatefulWidget> createState() => _SearchCardPageState();
}

class _SearchCardPageState extends State<SearchCardPage>
    with TickerProviderStateMixin {
  static const String LIGHT_OFF = "OFF";
  static const String LIGHT_ON = "ON";
  static const String LIGHT_BLINK = "BLINK";

  late Function(String event, Map<String, dynamic> paramsMap) listener;
  late Animation<double> light1Animation;
  late Animation<double> light2Animation;
  late Animation<double> light3Animation;
  late Animation<double> light4Animation;
  late AnimationController light1Controller;
  late AnimationController light2Controller;
  late AnimationController light3Controller;
  late AnimationController light4Controller;

  String account = "";
  bool confirmEnable = false;
  String light1 = LIGHT_OFF;
  String light2 = LIGHT_OFF;
  String light3 = LIGHT_OFF;
  String light4 = LIGHT_OFF;

  @override
  void initState() {
    listener = (event, paramsMap) {
      switch (event) {
        case"FINISH_INPUT_ACCOUNT":
        case "FINISH":
          Navigator.of(context).pop();
          break;
        case "CONFIRM":
          setState(() {
            confirmEnable = paramsMap["enable"];
          });
          break;
        case "CLSS_LIGHT":
          setState(() {
            light1 = paramsMap["light1"];
            light2 = paramsMap["light2"];
            light3 = paramsMap["light3"];
            light4 = paramsMap["light4"];

            light1 == LIGHT_BLINK
                ? light1Controller.repeat(reverse: true)
                : light1Controller.reset();
            light2 == LIGHT_BLINK
                ? light2Controller.repeat(reverse: true)
                : light2Controller.reset();
            light3 == LIGHT_BLINK
                ? light3Controller.repeat(reverse: true)
                : light3Controller.reset();
            light4 == LIGHT_BLINK
                ? light4Controller.repeat(reverse: true)
                : light4Controller.reset();
          });
          break;
        case "MODE":
          setState(() {
            widget.swipe = paramsMap["swipe"] ?? false;
            widget.insert = paramsMap["insert"] ?? false;
            widget.tap = paramsMap["tap"] ?? false;
            widget.keyin = paramsMap["keyin"] ?? false;
          });
          break;
      }
    };

    POSLinkEventChannel().addListener(listener);

    light1Controller =
        AnimationController(vsync: this, duration: Duration(milliseconds: 500));
    light1Animation = new Tween(
      begin: 1.0,
      end: 0.0,
    ).animate(light1Controller);

    light2Controller =
        AnimationController(vsync: this, duration: Duration(milliseconds: 500));
    light2Animation = new Tween(
      begin: 1.0,
      end: 0.0,
    ).animate(light2Controller);

    light3Controller =
        AnimationController(vsync: this, duration: Duration(milliseconds: 500));
    light3Animation = new Tween(
      begin: 1.0,
      end: 0.0,
    ).animate(light3Controller);

    light4Controller =
        AnimationController(vsync: this, duration: Duration(milliseconds: 500));
    light4Animation = new Tween(
      begin: 1.0,
      end: 0.0,
    ).animate(light4Controller);

    super.initState();
  }

  @override
  void dispose() {
    POSLinkEventChannel().removeListener(listener);
    light1Controller.dispose();
    light2Controller.dispose();
    light3Controller.dispose();
    light4Controller.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    List<Widget> list = [];

    list.add(widget.tap
        ? Row(
            children: [
              Expanded(
                child: AnimatedBuilder(
                  animation: light1Animation,
                  builder: (context, child) {
                    return Opacity(
                      opacity: light1Animation.value,
                      child: Image.asset(
                        light1 == LIGHT_OFF
                            ? "assets/images/blue_off.png"
                            : "assets/images/blue_on.png",
                        height: 15,
                      ),
                    );
                  },
                ),
              ),
              Expanded(
                child: AnimatedBuilder(
                  animation: light2Animation,
                  builder: (context, child) {
                    return Opacity(
                      opacity: light2Animation.value,
                      child: Image.asset(
                        light2 == LIGHT_OFF
                            ? "assets/images/yellow_off.png"
                            : "assets/images/yellow_on.png",
                        height: 15,
                      ),
                    );
                  },
                ),
              ),
              Expanded(
                child: AnimatedBuilder(
                  animation: light3Animation,
                  builder: (context, child) {
                    return Opacity(
                      opacity: light3Animation.value,
                      child: Image.asset(
                        light3 == LIGHT_OFF
                            ? "assets/images/green_off.png"
                            : "assets/images/green_on.png",
                        height: 15,
                      ),
                    );
                  },
                ),
              ),
              Expanded(
                child: AnimatedBuilder(
                  animation: light4Animation,
                  builder: (context, child) {
                    return Opacity(
                      opacity: light4Animation.value,
                      child: Image.asset(
                        light4 == LIGHT_OFF
                            ? "assets/images/red_off.png"
                            : "assets/images/red_on.png",
                        height: 15,
                      ),
                    );
                  },
                ),
              ),
            ],
          )
        : SizedBox(
            height: 15,
          ));

    list.add(Row(
      children: [
        Text("Total Amount"),
        Expanded(
          child: Text(
            "\$" + widget.amount.toStringAsFixed(2),
            textAlign: TextAlign.right,
          ),
        )
      ],
    ));

    if (widget.keyin) {
      list.add(Text("Please Input Account"));

      list.add(Container(
        height: 50,
        alignment: Alignment.center,
        child: widget.outInput
            ? null
            : TextField(
                onChanged: (text) {
                  setState(() {
                    account = text;
                  });
                },
                keyboardType: TextInputType.number,
                inputFormatters: [FilteringTextInputFormatter.digitsOnly],
              ),
      ));
    }

    list.add(Row(
      children: [
        Expanded(
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Image.asset(widget.swipe
                ? "assets/images/swipe_card_en.png"
                : "assets/images/no_swipe_card_en.png"),
          ),
        ),
        Expanded(
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Image.asset(widget.insert
                ? "assets/images/insert_card_en.png"
                : "assets/images/no_insert_card_en.png"),
          ),
        ),
        Expanded(
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Image.asset(widget.tap
                ? "assets/images/untouch_card_en.png"
                : "assets/images/no_untouch_card_en.png"),
          ),
        ),
      ],
    ));

    list.add(Spacer());

    list.add(Padding(
      padding: const EdgeInsets.only(bottom: 30),
      child: MaterialButton(
        onPressed: confirmEnable ||
                (account.isNotEmpty &&
                    account.length >= widget.minAccountLength &&
                    account.length <= widget.maxAccountLength)
            ? () async {
                POSLinkMethodChannel().invokeMethod("INPUT_ACCOUNT", {
                  "account": account,
                });
              }
            : null,
        color: kMainColor,
        disabledColor: Colors.grey,
        textColor: Colors.white,
        disabledTextColor: Colors.white,
        child: Text("Confirm"),
      ),
    ));

    return WillPopScope(
      onWillPop: () async {
        await POSLinkMethodChannel().invokeMethod("CANCEL");
        return true;
      },
      child: Scaffold(
        appBar: AppBar(
          backgroundColor: kMainColor,
          elevation: 0,
          title: Text("Search Card"),
        ),
        body: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Column(
            children: list,
          ),
        ),
      ),
    );
  }
}
