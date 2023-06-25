import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { ListUserComponent } from './components/user/list-user/list-user.component';
import { CreateUserComponent } from './components/user/create-user/create-user.component';
import { EditUserComponent } from './components/user/edit-user/edit-user.component';
import { DeleteUserComponent } from './components/user/delete-user/delete-user.component';
import { AuthComponent } from './components/auth/auth.component';

const routes: Routes = [
  { path: 'auth', component: AuthComponent},
  { path: 'list-users', component: ListUserComponent},
  { path: 'create-user', component: CreateUserComponent},
  { path: 'edit-user', component: EditUserComponent},
  { path: 'delete-user', component: DeleteUserComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [
    LoginComponent,
    ListUserComponent,
    CreateUserComponent,
    EditUserComponent,
    DeleteUserComponent,
    AuthComponent
]