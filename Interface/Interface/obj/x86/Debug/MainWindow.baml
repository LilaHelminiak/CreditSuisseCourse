   M S B A M L   `   `   `  ����  	Interface    Interface.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Market��5   	   $	��600��6   $
��1000��6%   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5
   
   �� 5      .+�5   
   � $��0��6   $��0��6    5      �� 5      �� 5      .+�5      �� $��	Portfolio��6   $��0��6*   $��0��6:   $
��Auto��6G   $��
10,10,5,10q�6U   .��5      &   System.Windows.Controls.DataGrid  -   5        $��portfolioDataGrid��5         AutoGenerateColumns .     CanUserAddRows .  $��1��6�   $��3,3,3,3q�6�   ��64   �� *portfolioList+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Instrument��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 25* 6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *
Instrument+6`     5      $ Notional��6.   $	 25* 6]    6@   �� *
Notional+6]     5      $ Value��6-   $	 25* 6V    6<   �� *Value+6V     5      $ Delta��6-   $	 25* 6V    6<   �� *Delta+6V   5      5      �� 5      $��	PnL Chart��6   $��0��6*   $��1��6:   $
��Auto��6G   $��
10,5,10,10q�6U   .��5      �  5      �� 5       $��25 �6(   �� 5!      .+�5#      �� -   5        $��0��5#      $	��140��6*   $��2,0,2,2q�66   .��6[   Generate PnL chart to file6w   �� 5$      $��1��6   $��PnLchart.jpg��6)   $
��Fill=�6?   $��Center=�6N   $��Center=�6i   $��0,0,0,25q�6�   5%      5&      5'      �� 5)   
   $��Market��6   $��1��6#   $��0��63   $��1��6@   $
��Auto��6T   $��
0,10,10,10q�6b   .��5*      � -   5        $��
gridMarket��5*       5+      �� 5,      �� 5-      �� 5.      $��24 �6$   .+�50      �� -   5        $��MarketPrice��50      $��0��6,   �� 51      -   5        $��	MarketVol��51      $��0��6)   $��Center=�66   �� 52      -   5        $��
MarketDate��52      $��0��6*   $��Right=�67   �� 53      $��marketChart.jpg��6   $
��Fill=�61   $��Center=�6@   $��Center=�6[   $��0,25,0,0q�6x     54      -   5        $��optionDataGrid��54       .   .  $��1��6�   $��3,3,3,3q�6�   ��61   �� *
optionList+ 55        56      $
 Type��6-   $	 25* 6T    6;   �� *Type+6T     57      $ Maturity��6.   $	 25* 6x    6@   �� *
Maturity+	 �� StringFormat$	 
yyyy-MM-dd��6x     58      $ Price��6-   $	 25* 6V    6<   �� *Price+6V   4  .System.Windows.Controls.DataGridTemplateColumn  59      $ Trade��61   $	 25* 6@   
   CellTemplate
 5:      �� 5;   "   .R�5<   &   �� -   5        .��5<   D   Add to Portfolio6V   5=   #   5?      5A      �� 5B      -	   5        $��3��5B      $	��140��6&   $��2,0,2,2q�62   .��6U   Add new option6e   5C      5D      5E      5F      