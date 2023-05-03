import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})

export class NavMenuComponent implements OnInit {
  isExpanded = false;
  loggedinUser!: string | null;

  constructor(private alertify: AlertifyService) { }

  ngOnInit() { }

  loggedin() {
    this.loggedinUser = localStorage.getItem('userName');
    return this.loggedinUser;
  }

  onLogout() {
    localStorage.removeItem('token');
    localStorage.removeItem('userName');
    this.alertify.success('You are logged out !');
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
