   M S B A M L   `   `   `  ���� F  BVinaRenamer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:VinaRenamerVinaRenamer      VinaRenamer.HScreen   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:VinaRenamer     -     � Title$  VinaRenamer��$	��600��$
��1000������ *color2+.���  � RowDefinitions �� $��3* ��� $
��0.5* ��� $��9* ��� $��50 � � ColumnDefinitions �� $��1* ��� $��4* ��� $��2* ��� $��5* ��� $��5* ��� $��1* �.+��� $��0��$��1�� �� Orientation$ Vertical=�$��Center=�$��Center=�.+���    addARule#���   $��Center=�$��0, 0, 0, 13q�$��35(�$��Medium"����� *
textColor1+�� $ 
Horizontal=�.+��� -    ��Name$ 
cmbGUIList��$��30��$��15(��� -    ��Name$ OK��  add#���  $��10, 0, 0, 0q����� *
textColor1+����  �� 
TargetType" ��.���  �� Property � �� �� Value �� *buttonColor2+��  �@�Cursor$
 Hand����  � ��$ 15(���  � ��$ Medium"�	 �� Triggers	 P� 
 P� Property
 �@J�IsMouseOver P� Value . . ���  � �� �� *buttonColor2_press+����  �� 
TargetType" ��.R��� $��60��$��30�� �� CornerRadius$ 6��#��z��
���   �$��1q�._��� $��Center=�$��Center=��� $��0��$��3��$ Vertical=�$��Center=�$��Center=�$��0, 15, 0, 0q��� -   $ rename��$��4��$��0��$��Rename!��$��45,30,45,30q����� *
textColor1+���� " ��.���  � �� �� *buttonColor3+��  �@�Cursor$
 Hand����  � ��$ 25(���  � ��$ Light"�	 P� 
 �@J�IsMouseOver . . ���  � �� �� *buttonColor3_press+���� " ��.R��� $
��auto��$
��auto��$ 2��#��z��
���   �$��2q�._��� $��Center=�$��Center=�� $��2��$��1�� �� $
��1.5* ��� $	��15* ��� $��2* �.+��� $��0��$��0��$��18(�  currentRules#���  $��Center=�$��Center=����� *
textColor1+�� -    ��Name$
 rule��$��1��$��0��$
��Auto=�$��Disabled=�$��0, 0, 0, 15q����� *listViewColor+ � 	Resources   currentRule��%>   &	       �� .@�m� -   $��delete��m� -   $
��edit������ " ��.���  �@�ContextMenu# [ ���� .R��� .+���  ��Name$ ruleName��$��15(�$
��Wrap=�$��
0, 0, 0, 3q�$��Medium"����� *name+�� $��12(�$
��Wrap=�$��Light"����� *description+�� $��Center=�$��2��$ 
Horizontal=�.+��� -   $
 load��  loadOldRules#���  $��
0, 0, 0, 0q����� *
textColor1+���� " ��.���  � �� �� *buttonColor1+��  �@�Cursor$
 Hand��	 P� 
 �@J�IsMouseOver . . ���  � �� �� *buttonColor1_press+���� " ��.R��� $	��130��$��25��$ 10��#��z��._��� $��Center=�$��Center=�� -	    �Name$ fileM��$��2��$��3�� �� $
��1.5* ��� $	��15* ��� $��2* �.+��� -
   $ 	modeTitle��$��0��$��0��$��18(�  fileName#���  $��Center=�$��Center=����� *
textColor1+�� -   $ origin��$��1��$��0��$
��Auto=�$��0, 0, 0, 15q����� *listViewColor+   
originMenu��%)   &	       �� .@�m� -   $��delete������ " ��.���  �@�ContextMenu# [ ���� .R��� .+��� $��
originName��$��12(�$
��Wrap=����� *origin+�� $��Center=�$��2��$ 
Horizontal=�.+��� -   $ browse_file��  
chooseFile#���  $��
0, 0, 0, 0q����� *
textColor1+���� " ��.���  � �� �� *buttonColor1+��  �@�Cursor$
 Hand��	 P� 
 �@J�IsMouseOver . . ���  � �� �� *buttonColor1_press+���� " ��.R��� $��80��$��25��$ 10��#��z��._��� $��Center=�$��Center=��� -   $ browse_folder��  chooseFolder#���  $��30, 0, 0, 0q����� *
textColor1+���� " ��.���  � �� �� *buttonColor1+��  �@�Cursor$
 Hand��	 P� 
 �@J�IsMouseOver . . ���  � �� �� *buttonColor1_press+���� " ��.R��� $��80��$��25��$ 10��#��z��._��� $��Center=�$��Center=�� -   $ folderM��$��2��$��3�� �� $
��1.5* ��� $	��15* ��� $��2* �.+��� $��0��$��0��$��18(� 	 
folderName#��� 	 $��Center=�$��Center=����� *
textColor1+�� -   $ originF��$��1��$��0��$
��Auto=�$��0, 0, 0, 15q����� *listViewColor+ ��%)   &	       �� .@�m� -   $��delete������ " ��.���  �@�ContextMenu# [ ���� .R��� .+��� $��
originName��$��12(�$
��Wrap=����� *origin+�� $��Center=�$��2��$ 
Horizontal=�.+��� -   $ browse_folder2��#���  $��30, 0, 0, 0q����� *
textColor1+���� " ��.���  � �� �� *buttonColor1+��  �@�Cursor$
 Hand��	 P� 
 �@J�IsMouseOver . . ���  � �� �� *buttonColor1_press+���� " ��.R��� $��80��$��25��$ 10��#��z��._��� $��Center=�$��Center=�� $��2��$��4�� �� $
��1.5* ��� $	��15* ��� $��1* ��� $��1* �.+��� $��0��$��0��$��18(� 
 preview#��� 
 $��Center=�$��Center=����� *
textColor1+�� -   $ preview��$��1��$��0��$
��Auto=�$��0, 0, 0, 15q����� *listViewColor+���� .R��� .+��� $��
originName��$��12(�$
��Wrap=����� *	newName+�� $��Center=�$��1��$ 
Horizontal=��� $��3��$��7��$��0��$��45������ *color1+.+��� $��Right=�$��Center=�$ 
Horizontal=�$��45��.+��� -   $ reset�� 	 reset#���  $��Center=�$��0, 0, 50, 0q�$��14(�$��5q���   duplicateSuffix#���  $��14(�$��25, 0, 10, 0q�$��Center=����� *
textColor1+�� -    ��Name$ 	duplicate��$	��125��$��0,0,25,0q�$��25��$��Center=�$��14(�$��Center=��� -   $ rename_folder��  renameFolder#���  $��Center=�$��0, 0, 10, 0q�$��14(����� *
textColor1+   VinaRenamer.ToggleButton  -     Name$ folder��   VinaRenamer.ToggleButton   MouseLeftButtonDown$, &ToggleButtonFolder_MouseLeftButtonDown��$��30��$
��auto��$
��Left=���   darkMode#���  $��14(�$��25, 0, 10, 0q�$��Center=����� *
textColor1+  -   $ darkModeBtn��$&  ToggleButton_MouseLeftButtonDown��$��30��$
��auto��$
��Left=���   language#���  $��14(�$��25, 0, 10, 0q�$��Center=����� *
textColor1+�� -   $��currentLanguage��$!��./Images/MainWindow/Eng.png�� � Cursor$
 Hand��$��30��$��30��$��0, 0, 30, 0q�
 � Tag$ en-US��