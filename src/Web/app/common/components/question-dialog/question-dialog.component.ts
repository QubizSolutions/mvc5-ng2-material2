import { Component } from '@angular/core';
import { MdDialog, MdDialogRef } from '@angular/material';

@Component({
    moduleId: module.id,
    selector: 'question-dialog.component',
    styleUrls: ['question-dialog.component.css'],
    templateUrl: 'question-dialog.component.html',
})
export class QuestionDialogComponent {
    question: string = '';

    constructor(public dialogRef: MdDialogRef<QuestionDialogComponent>) { }
}