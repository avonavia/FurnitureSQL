   M S B A M L   `   `   `  ����G  CFurnitureSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FurnitureSQLFurnitureSQL  5   	       FurnitureSQL.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FurnitureSQL     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Вход��5	   	   $	��450��6   $	��800��6#   .��5
      � ���	#FFF1F5FB.+�5   
   �� -   5         ��Name$ 	login_box��5      $��Center=�6%   $��24��6B    �� TextWrapping$
 Wrap=�6N   $�� ��6b   $��Center=�6j   $	��166��6�   $��Proxima Nova)�6�   $��	0,0,0,100q�6�   �� 5   
   -   5        $ password_box��5      $��Center=�6(   $��24��6E   $��0q�6Q   $
 Wrap=�6\   $�� ��6p   $��Center=�6x   $	��166��6�   �� 5   
   -   5         ��Name$ Enter_button��5      $��Ввести��6'   $��Center=�68   $��39��6U   $��Center=�6a   $	��100��6|   ���	#FF89C2EF���	#FF1B262C$��Proxima Nova)�6�   $��15(�6�   $
��Bold"�6�   $��	0,100,0,0q�6  �� 5   
   -   5        $ 
Reg_button��5      $*��$Зарегистрироваться��6%   $��Center=�6B   $��39��6_   $��Center=�6k   $	��200��6�   ���	#FF89C2EF���	#FF1B262C$��Proxima Nova)�6�   $��15(�6�   $
��Bold"�6�   $��	0,220,0,0q�6�   6  �� 5   
   $��Логин:��6   $��Center=�6!   $��33��6>   $��0,0,230,100q�6J   $��Center=�6_   $��50��6z   $��Proxima Nova)�6�   $
��Bold"�6�   �� 5   
   $��Пароль:��6   $��Center=�6"   $��33��6?   $��	0,0,240,0q�6K   $��Center=�6^   $��60��6y   $��Proxima Nova)�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ CapchaLable��5      $-��'Введите символы ниже:��6%   $��33��6E   $	��170��6Q   $��Proxima Nova)�6]   $
��Bold"�6w   $��0,0,100,100q�6�   $��Right=�6�   $��Center=�6�   �� 5   
   -   5        $ 
capcha_box��5      $��Right=�6&   $��23��6B   $
 Wrap=�6N   $�� ��6b   $��Center=�6j   $	��166��6�   $��Proxima Nova)�6�   $��
0,60,110,0q�6�   �� 5   
   -   5        $ GeneratedCapchaLabel��5      $��33��6.   $	��123��6:   $��Curlz MT)�6F   $
��Bold"�6\   $��Right=�6n   $��Center=�6�   $��20(�6�   $��
0,0,130,30q�6�   �� 5   
   -   5        $ CapchaButton��5      $��Ввести��6'   $��Right=�68   $��24��6T   $��Center=�6`   $��59��6{   $��	0,60,30,0q�6�   ���	#FF89C2EF���	#FF1B262C$��Proxima Nova)�6�   $��12(�6�   $
��Bold"�6�   6  5      5      