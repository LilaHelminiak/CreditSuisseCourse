   M S B A M L   `   `   `  ����   BasicMVVMQuickstart_Desktop'    !TradingUI.Views.QuestionnaireView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .��� -     �Name$  
LayoutRoot�� � RowDefinitions �� $
��Auto � � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��0��$��3��$��Stretch=�.���  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��   HeaderedBorderStyle#��[  ._��  �� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Bottom=��� $
�Name���� -    ��Name$ NameTextBox��$��1��$��0��$	��150��$��2q�4  .System.Windows.Automation.AutomationProperties   AutomationId$ NameText������ *Questionnaire.Name+ �� Mode$ TwoWay=��� $��0��$��1��$��Bottom=��� $	�Age���� -   $ 
AgeTextBox��$��1��$��1��$
��Left=� �� 	MaxLength$ 3��$��40��$��2q�$ AgeText������ *Questionnaire.Age+$ TwoWay=�� $��1��$��5q� �� $
��Auto ��� $
��Auto � �� $��* �.+��� $��0��$��What is your quest?��  QuestionLabelStyle#��[ �� -   $ Question1Response��$��1��$ Question1Text������ *Questionnaire.Quest+$ TwoWay=�� $��2��$��5q� �� $��* � �� $
��Auto ��� $
��Auto �.+��� $��0��#��[ �� $�What is your favorite ���� -    ��Name$ ColorRun��$�color������ *Questionnaire.FavoriteColor+ �� TargetNullValue$ Black���� $�?���� $��1��  BorderBrush#��[ ._��� -   	 ��Name$	 Colors����.  $��5q����� *	AllColors+
 �� SelectedItem
 �� *Questionnaire.FavoriteColor+$ TwoWay=�