   M S B A M L   `   `   `  ����  	TradingUI%    TradingUI.Views.ConfigureMarket   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ConfigureMarket��5   	   $	��400��6!   $	��350��6.   .��5      �  � RowDefinitions 5   
   �� 5      $��90 �6   �� 5      �� 5	      �� 5
      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��2��6   $�� Configure the market:��6$   $��30,5,0,0q�6E   �� 5   
   $��2��6   $?��9 1. Create options that shall be available in the market ��6(   $��	30,30,0,0q�6i   �� 5   
   $��2��6   $'��!     before the simulation starts��6(   $��	30,45,0,0q�6Q   �� 5   
   $��2��6   $=��7 2. Fill the required configuration data in format 0.00��6(   $��	30,70,0,0q�6g   �� 5   
   $��1��6   $��Center=�6   $��Right=�69   .��6U   Drift of GBM:6d   �� 5   
   $��1��6   $��1��6   $��25��6/   $	��110��6;   $
��Left=�6G   6d   �� 5   
   $��2��6   $��Center=�6   $��Right=�68   $��-90, 0, 0, 0q�6T   .��6j   Volatility of GBM:6~   �� 5   
   $��2��6   $��1��6   $��25��6/   $	��110��6;   $
��Left=�6G   6d   �� 5   
   $��3��6   $��Center=�6   $��Right=�69   $��-90, 0, 0, 0q�6U   .��6k   Hedging volatility:6�   �� 5    
   $��3��6   $��1��6   $��25��6/   $	��110��6;   $
��Left=�6G   6d   �� 5"   
   $��4��6   $��Center=�6   $��Right=�68   $��-90, 0, 0, 0q�6T   .��6j   Seed:6r   �� 5#   
   $��4��6   $��1��6   $��25��6/   $	��110��6;   $
��Left=�6G   6d   �� 5%   
   $��5��6   $��Center=�6   $��Right=�68   $��-90, 0, 0, 0q�6T   .��6j   Stock price:6y   �� 5&   
   $��5��6   $��1��6   $��25��6/   $	��110��6;   $
��Left=�6G   6d   �� 5(   
   $��6��6<   $	��100��6I   $��25��6U   ��6   �� *StartSimulationCommand+.��6a   Start simulation6s   �� 5)   
   $��6��68   $��1��6E   $	��100��6U   $��25��6a   ��6   �� *CloseWindowCommand+.��6m   Cancel6u   5+      5,      