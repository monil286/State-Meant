   M S B A M L   `   `   `  ����	  Login    Login.RemoveStudent   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  RemoveStudent��5   	   $	��700��6   $
��1050��6,    � WindowStartupLocation$ CenterScreen=�69   .��5      � ��5   
   �� 5       �� ImageSource$' !E:\StateMent\login_background.png��6   .+�5
   
   �� $��200, 15, 200, 540q�6   $��State-Meant��6+   
�������$��Normal$�6T   $��	ExtraBold"�6g   $��Old English Text MT)�6~   $��80(�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��Center=�6�   z�5      V� 5      .~�5      ��  �� ScaleX$ 2Q�6%   �� 5      �� 5      T� 5      5      5      �� 5   
   -   5         ��Name$ RemoveHeader��5      $��375, 150, 375,450q�6&   $��Remove Student��6A   $��50(�6Z   $��Italic$�6h   
��� ���$��Edwardian Script ITC)�6�   $
��Bold"�6�   �� 5   
   -   5        $ FindFNameLbl��5      $��325, 250, 560, 375q�6&   $��First Name : ��6B   $��Comic Sans MS)�6Z   $��20(�6u   
��� ���$
��Bold"�6�   $��Italic$�6�   �� 5   
   -   5         ��Name$ FindFnameBtn��5      $��490, 250, 400, 375q�6)   �� 5   
   -   5        $ FindLNameLbl��5      $��330, 310, 560, 315q�6&   $��Last Name : ��6B   $��Comic Sans MS)�6Y   $��20(�6t   
��� ���$
��Bold"�6�   $��Italic$�6�   �� 5   
   -   5        $ FindLnameBtn��5      $��490, 310, 400, 315q�6)   �� 5   
   -   5         ��Name$ Search��5      $��Search for student��6!   $��280,441,575,179q�6>   $��Comic Sans MS)�6W   $��18(�6r   
�������
����  �$��Italic$�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $
 Back��5      $
��Back��6   $��480, 440, 425, 180q�6.   $��Comic Sans MS)�6J   $��18(�6e   
�������
����  �$��Italic$�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $
 Exit��5      $
��Exit��6   $��640, 440, 275, 180q�6.   $��Comic Sans MS)�6J   $��18(�6e   
�������
����  �$��Italic$�6�   $
��Bold"�6�   6�   �� 5   
   -	   5        $ Remove��5      $��Remove Student��6!   $��280, 440, 575, 180q�6:   $��Comic Sans MS)�6V   $��18(�6q   
�������
����  �$��Italic$�6�   $
��Bold"�6�   $y�Hidden=�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -
   5          Name$ Student_List��5      $��300, 250, 400, 315q�6)   $y�Hidden=�6E   	   AutoGenerateColumns	 . $��2q�6u   
��� ���6�   5      5       