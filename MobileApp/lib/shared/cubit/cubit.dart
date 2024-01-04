import "package:flutter_bloc/flutter_bloc.dart";
import "states.dart";
import "../network/remote/dio_helper.dart";
class AppCubit extends Cubit<AppStates>{
  int currentLayout = 0;
  final List<bool> showUDetails = <bool>[false, false];
  AppCubit():super(AppInitialState());
  void reload(){
    DioHelper.dio.get("api/")
  }
  void changeLayout(final int i){
    currentLayout = i;
    emit(AppChangeLayoutState());
  }
  void toggleU(final int i){
    showUDetails[i] = !showUDetails[i];
    emit(AppToggleUserDetails());
  }
}