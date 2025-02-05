import { Component, output, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  private readonly accountService = inject(AccountService);
  private readonly toastr = inject(ToastrService);
  cancelRegister = output<boolean>();
  registerModel: any = {};

  register() {
    this.accountService.Register(this.registerModel).subscribe({
      next: (response) => {
        console.log(response);
        this.toastr.success('Registration successful');
        this.cancel();
      },
      error: (error) => {
        this.toastr.error(error.error);
      },
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
