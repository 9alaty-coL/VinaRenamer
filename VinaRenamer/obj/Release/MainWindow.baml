   M S B A M L   `   `   `  ���� F  BVinaRenamer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:VinaRenamerVinaRenamer      VinaRenamer.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:VinaRenamer     -     � Title$  VinaRenamer��$	��500��$	��900�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=����� *color2+.���  � RowDefinitions �� $��30 ��� $��1* ��� $��45 � � ColumnDefinitions �� �� .+�� -   $��2������ *color1+ �� �� �� �� �� �� �� �� �� �� �� �� �� �� .+��� $��19120564��$��Medium"�$��1��$��Center=�$��Right=�$��0,0,9,0q����� *
textColor1+�� -      aboutMe#���    � Cursor$
 Hand��$��3��$��Center=�$��Center=����� *
textColor2+�� -     
sourceCode#���  $
 Hand��$��5��$��Center=�$��Center=����� *
textColor2+�� -    	 close#���  $��Medium"�$��13(�$��	40,0,10,0q�$��12��$��2������ *
textColor1+����  �� 
TargetType" ��.���  �� Property � �� �� Value �� *buttonColor1+��  �@�Cursor$
 Hand��	 �� Triggers	 P� 
 P� Property
 �@J�IsMouseOver P� Value . . ���  � �� �� *buttonColor1_press+����  �� 
TargetType" ��.R��� $��65��$��18�� �� CornerRadius$ 10��#��z��._��� $��Center=�$��Center=��� -     minimize#���  $��13(�$��	64,0,10,0q�$��10��$��3��$��30��$	��Top=����� *
textColor1+���� " ��.���  � �� �� *buttonColor2+��  �@�Cursor$
 Hand��	 P� 
 �@J�IsMouseOver . . ���  � �� �� *buttonColor2_press+���� " ��.R��� $��65��$��18��$ 10��#��z��._��� $��Center=�$��Center=��� $��1��$��Center=�$��40q�.+��� $��
20,-30,0,0q�.+���  �� Orientation$ 
Horizontal=�$��0,0,0,30q�.+��� $��85.15��$��65��$"��./Images/MainWindow/logo.png�� �� BitmapScalingMode$ HighQuality=��� $��VinaRenamer��$��31(�$��Medium"�$��Center=�$��10,0,0,0q����� *
textColor1+�� $ Vertical=�$��	30,0,30,0q�.+���  
 course#���  $��20(�$��Medium"�$��0,0,0,5q����� *
textColor1+��   teacher#���  $��20(�$��Medium"�$��0,0,0,5q����� *
textColor1+��  
 slogan#���  $��12(�$��Medium"�$
��Wrap=�$��
0,20,0, 15q����� *
textColor1+�� $ Vertical=�$��0, 25, 0, 0q�.+��� -    	 start#���  $��Medium"�$��22(�$��0,0,10,0q����� *
textColor1+���� " ��.���  � �� �� *buttonColor1+��  �@�Cursor$
 Hand��	 P� 
 �@J�IsMouseOver . . ���  � �� �� *buttonColor1_press+���� " ��.R��� $	��150��$��40��$ 20��#��z��._��� $��Center=�$��Center=��� $��1��$��1��$��Center=�$
��Left=�$��80,0,0,0q�.+��� $$��./Images/MainWindow/rename.png��$	��200�� J� Opacity$	 0.8Q��� $��2��$��2��$��Bottom=�$��35������ *color1+.+��� $��Right=�$��Center=�$ 
Horizontal=�.+���   darkMode#���  $��2��$��0��$��14(�$��0, 0, 10, 0q�$��Center=����� *
textColor1+   VinaRenamer.ToggleButton  -     Name$ darkModeBtn��   VinaRenamer.ToggleButton   MouseLeftButtonDown$&  ToggleButton_MouseLeftButtonDown��$��30��$
��auto��$
��Left=���  	 language#��� 	 $��14(�$��25, 0, 10, 0q�$��Center=����� *
textColor1+�� -	   $��currentLanguage��$!��./Images/MainWindow/Eng.png��$
 Hand��$��30��$��30��$��0, 0, 30, 0q�
 � Tag$ en-US��� $��1��$��2��$��0, -365, -610, -100q� K� ZIndex$ -1��z���  �� Angle$ 40Q�.+��� $ 
Horizontal=�$��0, 200, 0, 0q�.+��� .+��� $	��700��$��35�����#3DDDC2$��150,-200,0,0q�$ 20���� $	��700��$��35�����#383660$��	0,-90,0,0q�$ 20���� $	��700��$��35��$��0, 650 ,0,0q�$ 20������ *buttonColor1+