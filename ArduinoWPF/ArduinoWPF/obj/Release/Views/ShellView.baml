   M S B A M L   `   `   `  ���� E  AArduinoWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ArduinoWPF.ViewsArduinoWPF.Views  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf      ArduinoWPF.Views.ShellView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:ArduinoWPF.Views     T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  $	��700��$	��600��  � Icon$  resistance.ico��.���  � RowDefinitions �� $
��0.5* ��� $
��2.5* ��� $
��2.5* ��� $��0.55* �.+�o�  o� 
IsMainMenu . $��0��.@�m� $��_File��.@�m� $
��Open�� m� Icon '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 File=�m� $
��Save��   $ ContentSave=��� m� $
��Exit�� m� InputGestureText$ Ctrl+E��   $ 	ExitToApp=�m� $��_Simulation��.@�m� -    m�Name$ SimulItem_Click��$��Start��   $ ChartTimelineVariant=�m� -   $ 
Stop_Click��$
��Stop��   $ CloseOctagon=�m� $��_Help��.@�m� -   $ MenuItem_Click��$��Information��   $ About=�� $��1�� �� $
��0.5* ��� $��0.25* ��� $
��0.5* ��� $
��0.5* ��� $��* � � ColumnDefinitions �� $
��203* ��� $	��93* ��� $	��148 ��� $
��148* �.+��� $��0��$��0��$��Center=�$��15q�$��
ExtraBlack"�$��15(�$��2������ *Connet_Time+�� -    ��Name$ TxtSensorCount��$��0��$��2��$��15(����#CdCdCd   MaterialDesignTextBlock#��[  $��5,5,5,0q�$��40��	 �� TextAlignment$	 Center=��� $��0��$��3��$��5��$��포트��  MaterialDesignCardGroupBox#���  $��5q�.  (MaterialDesignThemes.Wpf.ColorZoneAssist
   Mode$
 Custom=�   
Background �#CdCdCd   
Foreground
 �   ����� .R���  �� Orientation$ 
Horizontal=�.+�  $ TransitConnectionVariant=�$��20��$��20��$��Center=��� $��8,0,0,0q�$��Center=� $  MaterialDesignSubtitle1TextBlock#��[ ���� .���� .+��� -    ��Name$ Ports�� & "MaterialDesignFloatingHintComboBox#��[ $��40��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Choose a port��$��Bottom=� �� SelectedItem �� *SelectedPort+ �� Text �� *SelectedPort+�� -    ��Name$ Connect_Click��$��Center=�$��40��  MaterialDesignRaisedButton#��[ +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10�� � ToolTip$* $선택된 포트에 연결합니다.��$	��0,2q�.���� $��CONNECT��$��13(��� -   $ 
Disconnect��$��Center=�$��40��#��[ $ 10��$' !포트 연결을 종료합니다.��$	��0,2q�.���� $��
DISCONNECT��$��13(��� -   $ 
Port_Click��$��Stretch=�#��[ $ 10��$��80��$	��0,2q�.���� $��Center=�$��25(�$��DemiBold"����� *BtnPortValue+�� $��1��$��0��$��3��$��3��$��포토레지스터��#���  $��5,4.6,4.8,0q�$
 Custom=� �#CdCdCd
 �   �$	��117��$	��Top=����� .R��� $ 
Horizontal=�.+�  $ ResistorNodes=�$��20��$��20��$��Center=��� $��8,0,0,0q�$��Center=�#��[ ���� .���� .+�� $��20��;  5MaterialDesignThemes.Wpf.Transitions.TransitionAssist   DisableTransitions .  � Maximum$
 1024Q� � Value �� *
PhotoValue+�� $ 
Horizontal=�$��Center=�.+��� ���#303030$��18(����� *
PhotoValue+ �� StringFormat$ {0:N0}���� -	    ��Name$ RtbLog��  ConsoleTextBox#��[  �� 
IsReadOnly . $��4��$��0��$��3�� �� TextWrapping$
 Wrap=�$��Stretch=�$	��280�� �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=� �� 	IsEnabled . $ Data from Arduino��$��80��$��	0,10,0,11q�.  (MaterialDesignThemes.Wpf.ScrollBarAssist   ButtonsVisibility$ Hidden=�.��� $��2�����#CE2156$��5q�.+��  �� $
��207* ��� $	��89* � �� $
��Auto ��� $��* �.+��� $��2���� $��0��$��0��$ 
Horizontal=�$��25, 10q�.+�F� $��25��$��25��  �� Stretch$
  Fill=����#4C4949�������C�Q0 ӌai�Q0 YWtIYW��C�YW�ai�aiYW��CYW�tIYW�Q0 �ai�Q0 ��C��Q0 tItI�Q0 ��C�Q0 �`M��!ѐ�+��!�pejD�[є�D�[ѐ��,�����р�C���`M��!�� $��10, 0q�.+��� $��22(�
�������Data From Arduino�� $��14(����	#7CFFFFFF$��날짜��#  LiveCharts.Wpf.CartesianChart  -
   !  Name$! SensorValues��$��1��$��0��$��2��$��15q�&   LiveCharts.Wpf.Charts.Base.Chart"   Series" 	  LiveCharts.Wpf.LineSeries	  # 	  LineSmoothness$# 1Q�
  LiveCharts.Wpf.Series$ 
  StrokeThickness$$ 3Q�% 
  
DataLabels% . & 
  FontSize$& 12Q�' 
  
Foreground' �	#6B303030( 
  Stroke
( �����) 
  Fill
) ���� * 	  PointForeground
* �  ��+ 	  PointGeometrySize$+ 12Q�, 	  	AreaLimit$	, -10Q�- 
  Values- �� *Values+.   AxisX.   LiveCharts.Wpf.Axis  /   MinValue$/ 0Q�{�.  0   
ShowLabels0 .  1   MaxValue1 �� *maxPhotoVal+2   AxisY2   3   
Foreground
3 �����4   FontSize$4 14Q�$/ 0Q�5   MaxRange$
5 1024Q�6   	Separator6   LiveCharts.Wpf.Separator  7   StrokeThickness$7 1Q�8   Stroke8 �	#8EFFFFFF9   StrokeDashArray$9 8R�:   Step$	: 300Q�� $��3��.+��� $ 
Horizontal=�$��Center=�.+��� -   $ Pause_Chart��$��1��$��Stretch=� # MaterialDesignRaisedLightButton#��[ $ 10��$ 일시중지 합니다.��$��40��$��5q�.���� $��20(����� *
StrPause+�� -   $ Clear_Chart��$��2��$��Stretch=�#��[ $ 10��$C =연결을 종료하고 화면의 차트를 초기화합니다��$��40��$��5q�.���� $��CLEAR��$��20(��� -   $ 	Close_App��$��2��$��Stretch=� " MaterialDesignFlatDarkBgButton#��[ $ 10��$&  앱을 완전히 종료합니다��$��40��$��5q�.���� $��CLOSE��$��20(�