import { Component, Inject, inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-admin-permission-dialog',
  templateUrl: './admin-permission-dialog.component.html',
  styleUrl: './admin-permission-dialog.component.css'
})
export class AdminPermissionDialogComponent implements OnInit {

  selection: string;

  constructor(
    public dialogRef: MatDialogRef<AdminPermissionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.selection = data.selection || 'Yes';
  }
  ngOnInit(){}

  onSave(value : string): void {
    this.selection = value;
    this.dialogRef.close(this.selection); //seçilen durumu geri döndür
  }

}
