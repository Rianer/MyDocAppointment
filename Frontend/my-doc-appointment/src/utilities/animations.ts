import { trigger, transition, style, animate } from "@angular/animations";

export const Animations = {
    verticalExpand : trigger('expandAnimation', [
        transition(
            ':enter',
            [
                style({height:0}),
                animate('300ms ease-out', style({height:400}))
            ]
        ),
        transition(
            ':leave',
            [
                style({height:400}),
                animate('300ms ease-in', style({height:0}))
            ]
        )
    ])
}