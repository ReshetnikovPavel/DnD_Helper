﻿using DnD_Helper.ViewModels;

namespace DnD_Helper;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel(Navigation);
	}
}

