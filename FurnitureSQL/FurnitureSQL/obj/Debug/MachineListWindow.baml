   M S B A M L   `   `   `  ����G  CFurnitureSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FurnitureSQLFurnitureSQL  5   	   $    FurnitureSQL.MachineListWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FurnitureSQL     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Оборудование��5	   	   $	��450��6   $	��800��6+   .��5
      � ���	#FFF1F5FB.+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ MachineGrid��5         SelectionMode$ Extended=�6(      SelectionUnit$ FullRow=�6A      AutoGenerateColumns .     
IsReadOnly . $	��250��6�   $	��250��6�   $	��430��6�   $	��430��6�   $��13(�6�   $��Center=�6�   $��Center=�6�   $��0q�6     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6>   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *Name+6>     5      $ Тип��6>   	 6%   �� *Type+6>     5      $ Статус��6@   	 6%   �� *Status+6@   5      �� 5   
   -   5        
 ��Name$
 Back_button��5      $��
Назад��6&   $
��Left=�66   $��39��6Q   $��Bottom=�6]   $	��100��6x   ���	#FF89C2EF���	#FF1B262C$��Proxima Nova)�6�   $��15(�6�   $
��Bold"�6�   $��	10,0,0,60q�6  �� 5   
   -   5        $
 Exit_button��5      $��
Выйти��6&   $
��Left=�66   $��39��6Q   $��Bottom=�6]   $	��100��6x   ���	#FF89C2EF���	#FF1B262C$��Proxima Nova)�6�   $��15(�6�   $
��Bold"�6�   $��	10,0,0,10q�6  �� 5   
   -   5        $
 
Add_button��5      $��Добавить��6%   $��Right=�68   $��39��6T   $	��Top=�6`   $	��150��6x   ���	#FF89C2EF���	#FF1B262C$��Proxima Nova)�6�   $��15(�6�   $
��Bold"�6�   $��	0,20,20,0q�6�   6�   �� 5   
   -   5        $
 Redact_button��5      $ ��Редактировать��6(   $��Right=�6@   $��39��6\   $	��Top=�6h   $	��150��6�   ���	#FF89C2EF���	#FF1B262C$��Proxima Nova)�6�   $��15(�6�   $
��Bold"�6�   $��	0,70,20,0q�6�   6  �� 5   
   -   5        $
 Add_char_button��5      $3��-Добавить характеристику��6*   $��Center=�6L   $��39��6i   $��Center=�6u   $	��200��6�   ���	#FF89C2EF���	#FF1B262C$��Proxima Nova)�6�   $��15(�6�   $
��Bold"�6�   $��0,320,230,0q�6  6  �� 5   
   -   5        $
 Show_char_button��5      $3��-Показать характеристики��6+   $��Center=�6M   $��39��6j   $��Center=�6v   $	��200��6�   ���	#FF89C2EF���	#FF1B262C$��Proxima Nova)�6�   $��15(�6�   $
��Bold"�6�   $��230,320,0,0q�6  6  5      5      