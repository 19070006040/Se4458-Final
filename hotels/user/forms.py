from django import forms


class LoginForm(forms.Form):
    username = forms.CharField(max_length=20, label = "Username")
    password = forms.CharField(max_length=20, label="Password",widget=forms.PasswordInput)

class RegisterForm(forms.Form):
    name = forms.CharField(max_length=20, label="İsim")
    surname = forms.CharField(max_length=20, label="Soyisim")
    mailadress = forms.CharField(max_length=100, label="Mail Adresi")
    password = forms.CharField(max_length=20, label="Parola",widget=forms.PasswordInput)
    confirm = forms.CharField(max_length=20, label="Parola Tekrar", widget=forms.PasswordInput)

    country = forms.CharField(max_length=20, label="Yaşadığınız Ülke")
    city = forms.CharField(max_length=20, label="Yaşadığınız Şehir")

    def clean(self):
        username = self.cleaned_data.get("name") + " " + self.cleaned_data.get("surname")
        mailadress = self.cleaned_data.get("mailadress")
        password = self.cleaned_data.get("password")
        confirm = self.cleaned_data.get("confirm")

        if password and confirm and password != confirm:
            raise forms.ValidationError("Parolalar Uyuşmuyor")
        
        values = {
            "username": username,
            "mailadress": mailadress,
            "password": password,
        }

        return values