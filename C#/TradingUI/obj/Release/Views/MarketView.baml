   M S B A M L   `   `   `  ����   BasicMVVMQuickstart_Desktop     TradingUI.Views.MarketView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .��� -     �Name$  
LayoutRoot��.+��� $��Market��$��1��$��0��$��1��$
��Auto��$��
0,10,10,10q�.��� -   $��
gridMarket�� � RowDefinitions �� �� �� $��24 �.+��� -   $��MarketPrice��$��Strike: ��$��0���� -   $��MarketPriceValue��$��0������ *Market.Price+�� -   $��	MarketVol��$��Volatility: ��$��0��$��Center=��� -   $��MarketVolValue��$��0��$��Center=����� *
Market.Vol+�� -   $��
MarketDate��$��Date: ��$��0��$��Right=��� -   $��MarketDateValue��$��0��$��Right=����� *Market.BusinessDate+ �� StringFormat$ 
yyyy-MM-dd���� $��0��$��0��$��25��$	��110��$��Configure Market��$	��Top=�$��Right=�$��0,25,0,0q����� *ConfigureMarketCommand+�� $��../Images/marketChart.jpg��$
��Fill=�$��Center=�$��Center=�$��0,55,0,0q�&   System.Windows.Controls.DataGrid  -	   $��optionDataGrid��   AutoGenerateColumns .     
IsReadOnly . $��1��$��10,10,10,10q����� *
optionList+ �� SelectedItem �� *selectedOption+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Type��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 25* 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *Type+  $ Maturity��$	 25* 	 �� *
Maturity+$ 
yyyy-MM-dd��  $ Price��$	 25* 	 �� *Price+�� $��3��$	��140��$��
-160,0,2,0q�$��Center=����� *AddOptionCommand+.��Add new option�� $��3��$	��140��$��
160,0,20,0q�$��Center=����� *TradeOptionCommand+.��Trade selected option