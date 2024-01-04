import "package:dio/dio.dart";
class DioHelper{
  static late final Dio dio;
  static init()
  =>dio = Dio(BaseOptions(
    baseUrl: "https://localhost:5225/",
    receiveDataWhenStatusError: true
  ));
}