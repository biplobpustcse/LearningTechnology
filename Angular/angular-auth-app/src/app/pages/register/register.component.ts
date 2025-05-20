import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
})
export class RegisterComponent {
  registerForm: FormGroup;
  errorMsg = '';

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]],
      name: ['', [Validators.required]],
    });
  }

  onSubmit() {
    if (this.registerForm.valid) {
      this.auth.register(this.registerForm.value).subscribe({       
        next: (res: any) => {         
          this.router.navigate(['/login']);
        },
        error: () => {        
          this.errorMsg = 'Registration failed.';
        }
      });
    }
  }
}
