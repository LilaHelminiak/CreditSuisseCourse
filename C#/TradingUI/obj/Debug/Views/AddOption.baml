   M S B A M L   `   `   `  ����  	TradingUI    TradingUI.Views.AddOption   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  	AddOption��5   	   $	��300��6   $	��300��6(   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��110 �6   �� 5       � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Center=�6   $��2��64   $��0,10,0,0q�6H   .��6Z   Define the option6m   �� 5   
   $��1��6   $��Right=�6   $	��Top=�6@   $��	0,-10,0,0q�6X   .��6k   Type:6r   �� 5   
   $��2��6   $��Right=�6   $	��Top=�6@   $��	0,-10,0,0q�6X   .��6k   	Maturity:6v   �� 5   
   $��3��6   $��Right=�6   $	��Top=�6@   $��0,-0,0,0q�6X   .��6j   Price:6r   	� 5   
   -   5        $��	PutButton��5      $��1��6G   $��1��6W   $	��Top=�6d   $��	10,-5,0,0q�6|    d� 	IsChecked 6'   �� *	PutButton+.��6�   Put6�   	� 5   
   -   5        $��
CallButton��5      $��1��6I   $��1��6Y   $	��Top=�6f   $��	60,-5,0,0q�6~    6(   �� *
CallButton+.��6�   Call6�   �� 5   
   -   5        $��typeWarningLabel��5      $��1��6U   $��1��6e   $	��Top=�6r   $��	10,10,0,0q�6�   
���  ����6(   �� *typeWarningLabel.Content+y�6�   �� *typeWarningLabel.Visibility+6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $
��Date��5      $��1��6G   $��2��6W   $
��Auto��6d   $	��Top=�6q   $��10,-10,20,0q�6�      SelectedDate 6!   �� *maturityDate+6�   �� 5   
   -   5        $��dateWarningLabel��5      $��1��6U   $��2��6e   $	��Top=�6r   $��	10,10,0,0q�6�   
���  ����6(   �� *dateWarningLabel.Content+y�6�   �� *dateWarningLabel.Visibility+6�   �� 5   
   -   5        $��Price��5      $��1��6    $��3��6N   $
��Auto��6[   $
��Auto��6h   $	��Top=�6v   $��	10,0,20,0q�6�   ��60   �� *priceTextbox+6�   �� 5   
   -   5        $��priceWarningLabel��5      $��1��6W   $��3��6g   $	��Top=�6t   $��	10,18,0,0q�6�   
���  ����6)   �� *priceWarningLabel.Content+y�6�   �� *priceWarningLabel.Visibility+6�   �� 5   
   $��4��6   $��50��6C   $��25��6N   $��Center=�6Z   $	��Top=�6w   $��2��6�   $��79,0,149,14q�6�   ��6   �� *AddOptionCommand+.��6�   Create6�   �� 5   
   $��4��6   $��50��6E   $��25��6P   $��Center=�6\   $	��Top=�6y   $��
35,0,83,14q�6�   $��1��6�   ��6   �� *CloseWindowCommand+.��6�   Abort6�   �� 5    
   $��4��6   $��2��6K   $��Center=�6_   $��0,20,0,0q�6|   
���  ����6   �� *existWarningLabel.Content+y�6�   �� *existWarningLabel.Visibility+6�   5!      5"      