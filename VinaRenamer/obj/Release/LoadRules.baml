   M S B A M L   `   `   `  ���� F  BVinaRenamer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:VinaRenamerVinaRenamer      VinaRenamer.LoadRules   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:VinaRenamer     -     � Title$  	LoadRules��$	��400��$	��600������ *color2+.���  � RowDefinitions �� $��1* ��� $��9* ��� $��1* ��� $��1* � � ColumnDefinitions �� $��1* ��� $	��10* ��� $��1* �.+�� $��1��$��1�� �� $��1* ��� $��5* � �� $��5* ��� $��1* �.+��� $��Set of rules��$��Center=�$��Center=�$��20(����� *
textColor1+�� -    ��Name$
 rule��$��1��$��0��$
��Auto=�$��Disabled=�$��0, 0, 0, 15q����� *listViewColor+���� .R��� .+��� $��12(�$
��Wrap=�$��Light"����� *Name+�� $��Quantity��$��Center=�$��Center=�$��1��$��15(����� *
textColor1+�� -   $	 num��$��1��$��1��$
��Auto=�$��Disabled=�$��0, 0, 0, 15q����� *listViewColor+���� .R��� .+��� $��12(�$
��Wrap=�$��Light"����� *
quantity+��  �� Orientation$ 
Horizontal=�$��2��$��1��$��Center=�$��Center=�.+��� -    ��Name$ Ok��$��ok��$��0, 0, 20, 0q�$��15(����� *
textColor1+����  �� 
TargetType" ��.���  �� Property � �� �� Value �� *buttonColor1+��  �@�Cursor$
 Hand��	 �� Triggers	 P� 
 P� Property
 �@J�IsMouseOver P� Value . . ���  � �� �� *buttonColor1_press+����  �� 
TargetType" ��.R��� $��50��$��27�� �� CornerRadius$ 10��#��z��._��� $��Center=�$��Center=��� -   $ Cancel��$��Cancel��$��15(����� *
textColor1+���� " ��.���  � �� �� *buttonColor1+��  �@�Cursor$
 Hand��	 P� 
 �@J�IsMouseOver . . ���  � �� �� *buttonColor1_press+���� " ��.R��� $��60��$��27��$ 10��#��z��._��� $��Center=�$��Center=�